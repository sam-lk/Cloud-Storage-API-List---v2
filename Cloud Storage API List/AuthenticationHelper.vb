Imports System
Imports System.Diagnostics
Imports System.Net.Http.Headers
Imports System.Threading.Tasks
Imports Microsoft.Graph
Imports Microsoft.Identity.Client

Namespace OneDriveApiBrowser
    Public Class AuthenticationHelper
        Private Shared clientId As String = Form1.MsaClientId
        Public Shared Scopes = {"Files.ReadWrite.All"}
        Public Shared IdentityClientApp = New PublicClientApplication(clientId)
        Public Shared TokenForUser As String = Nothing
        Public Shared Expiration As DateTimeOffset
        Private Shared graphClient As GraphServiceClient = Nothing

        Public Shared Function GetAuthenticatedClient() As GraphServiceClient
            Console.WriteLine(IdentityClientApp.ClientId)

            If graphClient Is Nothing Then

                Try
                    graphClient = New GraphServiceClient("https://graph.microsoft.com/v1.0", New DelegateAuthenticationProvider(Async Function(requestMessage)
                                                                                                                                    Dim token = Await GetTokenForUserAsync()
                                                                                                                                    requestMessage.Headers.Authorization = New AuthenticationHeaderValue("bearer", token)
                                                                                                                                    requestMessage.Headers.Add("SampleID", "uwp-csharp-apibrowser-sample")
                                                                                                                                End Function))
                    Return graphClient
                Catch ex As Exception
                    Debug.WriteLine("Could not create a graph client: " & ex.Message)
                End Try
            End If

            Return graphClient
        End Function

        Public Shared Async Function GetTokenForUserAsync() As Task(Of String)

            Dim authResult As AuthenticationResult
            Dim runningTryBlock As Boolean

            Try
                authResult = Await IdentityClientApp.AcquireTokenSilentAsync(Scopes)
                TokenForUser = authResult.Token
                runningTryBlock = True
            Catch __unusedException1__ As Exception
                runningTryBlock = False

            End Try

            If (runningTryBlock = False) Then
                If TokenForUser Is Nothing OrElse Expiration <= DateTimeOffset.UtcNow.AddMinutes(5) Then
                    authResult = Await IdentityClientApp.AcquireTokenAsync(Scopes)
                    TokenForUser = authResult.Token
                    Expiration = authResult.ExpiresOn
                End If
            End If

            Return TokenForUser
        End Function

        Public Shared Sub SignOut()
            For Each user In IdentityClientApp.Users
                user.SignOut
            Next

            graphClient = Nothing
            TokenForUser = Nothing
        End Sub
    End Class
End Namespace
