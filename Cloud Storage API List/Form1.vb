Imports System.Threading
Imports Google
Imports Google.Apis.Auth.OAuth2
'Imports Google.Apis.Drive.v2
'Imports Google.Apis.Drive.v2.Data
Imports Google.Apis.Drive.v3
Imports Google.Apis.Drive.v3.Data
Imports Google.Apis.Services
Imports Google.Apis.Auth
Imports Google.Apis.Download
Imports System.ComponentModel
Imports Dropbox.Api
Imports System.IO
Imports System.Net
Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports Google.Apis.Util.Store
Imports Microsoft.Graph
Imports System.Net.Http.Headers
Imports Microsoft.Identity.Client
Imports Cloud_Storage_API_List.OneDriveApiBrowser
Imports Dropbox.Api.Files

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblConnectionStatus.BackColor = Color.LightSkyBlue
        btnUploadFile.Enabled = False
        btnConnectToAPI.Enabled = False
        txtboxClientID.Enabled = False
        txtboxClientSecret.Enabled = False
        txtboxTokenKey.Enabled = False
        ComboBox1.Select()

    End Sub

    Dim selectedFileName As String
    Dim GoogleService As DriveService
    Dim MyGoogleDriveClient_ID = "845452680564-e72sc71ccgl7pil0113f3t1grkhvppjc-gfd.apps.googleusercontent.com"
    Dim MyGoogleDriveClientSecret = "gWKJ5_YdJ-PhomjNvLypJI6W1-Sfff"
    Dim MyGoogleApplicationName = "Google Drive VB Dot Net"
    Dim MyDropBoxToken As DropboxClient
    Dim MyDropBoxAccessTokenKey = "4Z6K-VPqImAAAAAAAAAAGE880gm6MsTHAOF3zcbfCuTZZRlcbcQYSuSbs-faL4iL1-SaS"

    Dim MyOneDriveClientAppID = "58989d3d-44ed-4e29-98a1-4d8f343267831-SaS"
    Dim MyOneDriveClientSecret = "-Y-z?V[vARHir9coaDHMHLGldk6NcV971-gfd"
    Dim MyOneDriveApplicationName = "OneDrive VB Dot Net"

    Public Const MsaClientId = "c1d232e5-7f54-456a-ac60-c518fcfed542"
    Public Const MsaReturnUrl = "urn:ietf:wg:oauth:2.0:oob"
    Private Property graphClientService As GraphServiceClient
    'Private Property clientType As ClientType
    Private Property CurrentFolderDriveItem As DriveItem
    Private Property SelectedItemDriveItem As DriveItem
    Dim pageList As New List(Of String)()
    Dim pageCount As Integer = 0


    Private Sub ComboBox1_DropDownClosed(sender As Object, e As EventArgs) Handles ComboBox1.DropDownClosed
        lblConnectionStatus.BackColor = Color.LightSkyBlue
        If (ComboBox1.SelectedItem = "DropBox") Then
            ClearTextbox()
            btnConnectToAPI.Enabled = True
            txtboxClientID.Enabled = False
            txtboxClientSecret.Enabled = False

            txtboxTokenKey.Text = MyDropBoxAccessTokenKey

        ElseIf (ComboBox1.SelectedItem = "Google Drive") Then
            ClearTextbox()
            btnConnectToAPI.Enabled = True
            txtboxTokenKey.Enabled = False

            txtboxClientID.Text = MyGoogleDriveClient_ID
            txtboxClientSecret.Text = MyGoogleDriveClientSecret

        ElseIf (ComboBox1.SelectedItem = "OneDrive") Then
            btnConnectToAPI.Enabled = True
            OneDirveSignIn()
            ' MessageBox.Show(ComboBox1.SelectedItem.ToString())

        End If
    End Sub

    Private Async Function OneDirveSignIn() As Task
        Try
            graphClientService = AuthenticationHelper.GetAuthenticatedClient()
        Catch ex As Exception

        End Try
        Try
            Await LoadFolderFromPath()
        Catch ex As Exception

        End Try
    End Function

    Private Async Function LoadFolderFromPath(ByVal Optional path As String = Nothing) As Task

        If Nothing Is graphClientService Then Return
        'LoadChildren(New DriveItem(-1) {})
        Try
            Dim folder As DriveItem
            Dim expandValue = If(Microsoft.OneDrive.Sdk.ClientType.Consumer, "thumbnails,children($expand=thumbnails)", "thumbnails,children")

            If path Is Nothing Then
                folder = Await graphClientService.Drive.Root.Request.Expand(expandValue).GetAsync
            Else
                folder = Await graphClientService.Drive.Root.ItemWithPath("/" & path).Request.Expand(expandValue).GetAsync
            End If

            Console.WriteLine("(LoadFolderFromPath method) SignIn: " & folder.Id)
            ProcessFolder(folder)

        Catch exception As Exception
            'PresentServiceException(exception)
        End Try
    End Function

    Private Sub ProcessFolder(ByVal folder As DriveItem)
        If folder IsNot Nothing Then
            CurrentFolderDriveItem = folder

            SelectedItemDriveItem = folder '// Load Properties

            If folder.Folder IsNot Nothing AndAlso folder.Children IsNot Nothing AndAlso folder.Children.CurrentPage IsNot Nothing Then
                Dim items As IList(Of DriveItem) = folder.Children.CurrentPage '// Load Children
                For Each obj In items
                    CreateListViewTableAndViewData(obj)
                Next
            End If

        End If
    End Sub

    Private Function CreateListViewTableAndViewData(ByVal item As DriveItem) As Control
        'Dim tile As OneDriveTile = New OneDriveTile(graphClientService)
        Dim NewItem = New ListViewItem

        Try
            NewItem.Text = item.Name

            If item.File.MimeType IsNot "" Then
                NewItem.SubItems.Add("File")
                NewItem.SubItems.Add(item.Size.ToString)
                NewItem.SubItems.Add(item.Id)
                NewItem.ImageIndex = 1
            End If

        Catch ex As Exception
            Console.WriteLine(ex.Message)
            NewItem.SubItems.Add("Directory")
            NewItem.SubItems.Add(item.Size.ToString)
            NewItem.SubItems.Add(item.Id)
            NewItem.ImageIndex = 0
        End Try

        MyCloud_ListviewTable.Items.Add(NewItem)
        'Return tile
    End Function

    Private Async Function LoadFolderFromId(ByVal id As String) As Task

        If Nothing Is graphClientService Then Return
        'LoadChildren(New DriveItem(-1) {})

        Try
            Dim expandString = If(Microsoft.OneDrive.Sdk.ClientType.Consumer, "thumbnails,children($expand=thumbnails)", "thumbnails,children")
            Dim folder = Await graphClientService.Drive.Items(id).Request.Expand(expandString).GetAsync
            ProcessFolder(folder)

        Catch exception As Exception
            'PresentServiceException(exception)
        End Try

    End Function

#Region "======== DropBox ========"
    'Dim MyDropBoxToken As New DropboxClient("4Z6K-VPqImAAAAAAAAAAGE880gm6MsTHAOF3zcbfCuTZZRlcbcQYSuSbs-fffaL4iL") 'token key assign
    Private Sub DropBoxConnection()

        Try
            MyDropBoxToken = New DropboxClient(txtboxTokenKey.Text)

            Dim Info = MyDropBoxToken.Users.GetCurrentAccountAsync
            lblConnectionStatus.Text = "Connected..!!"
            lblConnectionStatus.BackColor = Color.DarkSeaGreen

            Label1.Text = "Name : " & Info.Result.Name.DisplayName
            Label2.Text = "Email : " & Info.Result.Email

            Dim space = MyDropBoxToken.Users.GetSpaceUsageAsync
            Label3.Text = "Size : " & FileSize(space.Result.Used) & " / " & FileSize(space.Result.Allocation.AsIndividual.Value.Allocated)

        Catch ex As Exception
            lblConnectionStatus.Text = "Connection Error..."
            lblConnectionStatus.BackColor = Color.Red
            Return

        End Try


        MyCloud_ListviewTable.Items.Clear()
        'read dropbox data and add into listview table
        For Each Arquivos In MyDropBoxToken.Files.ListFolderAsync(String.Empty).Result.Entries
            Dim NewItem As New ListViewItem
            NewItem.Text = Path.GetFileName(Arquivos.Name)
            If Arquivos.IsFolder Then
                NewItem.SubItems.Add("Directory")
                NewItem.ImageIndex = 0
            Else
                NewItem.SubItems.Add("File")
                NewItem.SubItems.Add(FileSize(Arquivos.AsFile.Size))
                NewItem.ImageIndex = 1
            End If
            MyCloud_ListviewTable.Items.Add(NewItem)
        Next

    End Sub

    Private Function FileSize(ByVal Tamanho As Double) As String

        Dim Tipos As String() = {"B", "KB", "MB", "GB"}
        Dim TamanhoDouble As Double = Tamanho
        Dim CSA As Integer = 0
        While TamanhoDouble >= 1024 AndAlso CSA + 1 < Tipos.Length
            CSA += 1
            TamanhoDouble = TamanhoDouble / 1024
        End While

        Return [String].Format("{0:0.##} {1}", TamanhoDouble, Tipos(CSA))
    End Function

    Private Async Sub DropboxUploadFile(FilePath As String)
        'upload data and wait respond
        btnUploadFile.Enabled = False
        lblStatus.Text = "Uploading....!!!"
        'Dim Up = Await MyDropBoxToken.Files.UploadAsync(LbDiretorio.Text & "/" & Path.GetFileName(FilePath), body:=(New FileStream(FilePath, FileMode.Open, FileAccess.Read)))

        Upload(FilePath, LbDiretorio.Text & "/" & Path.GetFileName(FilePath))
        'after upload add data to dataview table
        'Dim NewItem As New ListViewItem
        'NewItem.Text = Path.GetFileName(Up.Name)
        'NewItem.SubItems.Add("File")
        'NewItem.SubItems.Add(FileSize(Up.Size))
        'NewItem.ImageIndex = 1
        'MyCloud_ListviewTable.Items.Add(NewItem)

        lblStatus.Text = "Upload Sucessfull.!! :)"
        MsgBox("Successfully Uploaded")
        btnAttachFile.Enabled = True
    End Sub

    Private Async Function Upload(ByVal localPath As String, ByVal remotePath As String) As Task
        Const ChunkSize = 4096 * 1024

        Using fileStream = IO.File.Open(localPath, FileMode.Open)

            If fileStream.Length <= ChunkSize Then
                Await Me.MyDropBoxToken.Files.UploadAsync(remotePath, body:=fileStream)
            Else
                Await Me.ChunkUpload(remotePath, fileStream, CInt(ChunkSize))
            End If
        End Using
    End Function

    Private Async Function ChunkUpload(ByVal path As String, ByVal stream As FileStream, ByVal chunkSize As Integer) As Task
        Dim numChunks As ULong = Math.Ceiling(stream.Length / chunkSize)
        Dim buffer = New Byte(chunkSize - 1) {}
        Dim sessionId As String = Nothing

        For idx As ULong = 0 To numChunks - 1
            Dim byteRead = stream.Read(buffer, 0, chunkSize)

            Using memStream = New MemoryStream(buffer, 0, byteRead)

                If idx = 0 Then
                    Dim result = Await Me.MyDropBoxToken.Files.UploadSessionStartAsync(False, memStream)
                    sessionId = result.SessionId
                Else
                    Dim cursor = New UploadSessionCursor(sessionId, CULng(chunkSize) * idx)

                    If idx = numChunks - 1 Then
                        Dim fileMetadata As FileMetadata = Await Me.MyDropBoxToken.Files.UploadSessionFinishAsync(cursor, New CommitInfo(path), memStream)
                        Console.WriteLine(fileMetadata.PathDisplay)
                    Else
                        Await Me.MyDropBoxToken.Files.UploadSessionAppendV2Async(cursor, False, memStream)
                    End If
                End If
            End Using
        Next
    End Function


    Private Async Sub DropboxDownloadFile(Filepath As String, Final As String)

        Dim Down = Await MyDropBoxToken.Files.DownloadAsync(LbDiretorio.Text & "/" & Path.GetFileName(Filepath))
        IO.File.WriteAllBytes(Final, Await Down.GetContentAsByteArrayAsync)
        lblStatus.Text = "Download Sucessfull.!! :)"
        MsgBox("Download successful...")
    End Sub

#End Region

#Region "===== Google Drive ======"
    Private Shared Scopes As String() = {DriveService.Scope.DriveReadonly}


    Private Sub CreateGoogleService()
        Try
            Dim MyUserCredential As OAuth2.UserCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(New ClientSecrets() With {.ClientId = txtboxClientID.Text.Trim(), .ClientSecret = txtboxClientSecret.Text.Trim()}, {DriveService.Scope.Drive}, "user", CancellationToken.None).Result
            GoogleService = New DriveService(New BaseClientService.Initializer() With {.HttpClientInitializer = MyUserCredential, .ApplicationName = MyGoogleApplicationName})

            'Label1.Text = GoogleService.Drives.List.Key
            'Dim credential As UserCredential

            'Using stream = New FileStream("credentials.json", FileMode.Open, FileAccess.Read)
            '    Dim credPath = "token.json"
            '    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, New FileDataStore(credPath, True)).Result
            '    Console.WriteLine("Credential file saved to: " & credPath)
            'End Using

            'Dim service = New DriveService(New BaseClientService.Initializer With {.HttpClientInitializer = credential, .ApplicationName = ApplicationName})

            lblConnectionStatus.Text = "Connected..!!"
            lblConnectionStatus.BackColor = Color.DarkSeaGreen

            '============///////////////////////////////////////////////////////////////////////////=============
            Dim listRequest As FilesResource.ListRequest = GoogleService.Files.List()
            Dim files As IList(Of Google.Apis.Drive.v3.Data.File) = listRequest.Execute().Files
            Console.WriteLine("Files:")

            For Each file In files

                Console.WriteLine("{0} ({1})", file.Name, file.Kind)
                Dim NewItem As New ListViewItem
                'NewItem.Text = Path.GetFileName(file.)
                NewItem.Text = file.Name

                If (file.MimeType = "application/vnd.google-apps.folder") Then
                    NewItem.SubItems.Add("Directory")
                    NewItem.SubItems.Add("")
                    NewItem.SubItems.Add(file.Id)
                    NewItem.ImageIndex = 0
                Else
                    NewItem.SubItems.Add("File")
                    NewItem.SubItems.Add("")
                    NewItem.SubItems.Add(file.Id)
                    NewItem.ImageIndex = 1
                End If
                MyCloud_ListviewTable.Items.Add(NewItem)

            Next



        Catch ex As Exception
            lblConnectionStatus.Text = "Connection Error..."
            lblConnectionStatus.BackColor = Color.DarkRed
        End Try
    End Sub

    Private Sub GoogleUploadFile(FilePath As String)
        btnUploadFile.Enabled = False
        lblStatus.Text = "Uploading....!!!"

        Dim TheFile As New Data.File()
        TheFile.Name = selectedFileName
        TheFile.Description = "Uploaded File From My VB.Net Application"
        '// Set the parent folder.
        '  If (!String.IsNullOrEmpty(parentId)) 
        '  {
        '  body.Parents = New List < ParentReference > ()
        '      { New ParentReference() {Id = parentId} };
        '  }
        Dim ByteArray As Byte() = System.IO.File.ReadAllBytes(FilePath)
        Dim Stream As New System.IO.MemoryStream(ByteArray)
        'Dim UploadRequest As FilesResource.InsertMediaUpload = GoogleService.Files.Insert(TheFile, Stream, TheFile.MimeType)

        Try
            Dim request As FilesResource.CreateMediaUpload = GoogleService.Files.Create(TheFile, Stream, TheFile.MimeType)

            request.Upload()
            Dim UpFile = request.ResponseBody
            lblStatus.Text = "Upload Sucessfull..!! :)"
            MsgBox("Upload successful...!!!")

            'after upload add data to dataview table
            Dim NewItem As New ListViewItem
            NewItem.Text = Path.GetFileName(UpFile.Name)
            NewItem.SubItems.Add("File")
            NewItem.SubItems.Add("")
            NewItem.SubItems.Add(UpFile.Id)
            NewItem.ImageIndex = 1
            MyCloud_ListviewTable.Items.Add(NewItem)

        Catch ex As Exception

            lblStatus.Text = "Upload Failed..!!  :- error : " & ex.Message
        End Try

        btnAttachFile.Enabled = True
    End Sub


    Private Async Sub GoogleDownloadFile(FileID As String, SavePath As String)

        Dim ds = New DriveService
        Dim req = GoogleService.Files.Get(FileID)
        Dim stream = New MemoryStream()

        Try
            lblStatus.Text = "Downloading File...!!"
            req.Download(stream)
        Catch ex As Exception
            Console.WriteLine("download to memory stream : " & ex.Message)
        End Try

        Try
            Using filesave = New FileStream(SavePath, FileMode.Create, FileAccess.Write)
                stream.WriteTo(filesave)
            End Using
            lblStatus.Text = "Download successfull...!!"
            MsgBox("Download successful...")
        Catch ex As Exception
            Console.WriteLine("file save : " & ex.Message)
            lblStatus.Text = "Download Failed...!!"
        End Try

    End Sub


#End Region

#Region "***** Connect : Button ****"
    Private Sub btnConnectCloud_Click(sender As Object, e As EventArgs) Handles btnConnectToAPI.Click
        If (ComboBox1.SelectedItem = "DropBox") Then
            DropBoxConnection()

        ElseIf (ComboBox1.SelectedItem = "Google Drive") Then
            CreateGoogleService()

        ElseIf (ComboBox1.SelectedItem = "OneDrive") Then

        End If
    End Sub
#End Region

#Region "***** Attach : Button *****"
    Private Sub btnAttachFile_Click(sender As Object, e As EventArgs) Handles btnAttachFile.Click

        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        Dim path As String = OpenFileDialog1.FileName

        If result = DialogResult.OK Then
            selectedFileName = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
            txtboxFileAttachPath.Text = OpenFileDialog1.FileName
            'UploadFile2(FilePath:=path)
            'button1.Enabled = False
            btnUploadFile.Enabled = True
            lblStatus.Text = "Ready to Upload..!!"
        Else
            Return
        End If

    End Sub
#End Region

#Region "***** Upload Now : Button ********"
    Private Sub btnUploadFile_Click(sender As Object, e As EventArgs) Handles btnUploadFile.Click
        If (ComboBox1.SelectedItem = "DropBox") Then
            btnAttachFile.Enabled = False
            DropboxUploadFile(FilePath:=txtboxFileAttachPath.Text)

        ElseIf (ComboBox1.SelectedItem = "Google Drive") Then
            btnAttachFile.Enabled = False
            GoogleUploadFile(FilePath:=txtboxFileAttachPath.Text)

        ElseIf (ComboBox1.SelectedItem = "OneDrive") Then

        End If
    End Sub
#End Region

#Region "***** Donwload File : Button *****"
    Private Sub btnDownloadFile_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        lblStatus.Text = "Ready to Download..."

        For Each T As ListViewItem In MyCloud_ListviewTable.SelectedItems

            Dim X As New SaveFileDialog
            X.Title = "Download File"
            X.Filter = "All File (*.*)|*.*"
            X.FileName = Path.GetFileName(T.Text) 'location and file name

            If X.ShowDialog = Windows.Forms.DialogResult.OK Then

                If (ComboBox1.SelectedItem = "DropBox") Then
                    DropboxDownloadFile(T.Text, X.FileName)

                ElseIf (ComboBox1.SelectedItem = "Google Drive") Then
                    Dim myID = T.SubItems.Item(3)
                    GoogleDownloadFile(myID.Text, X.FileName)

                ElseIf (ComboBox1.SelectedItem = "OneDrive") Then

                End If
            End If
        Next

    End Sub
#End Region

#Region "***** Remove File : Button *******"
    Private Sub btnRemoveFile_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        lblStatus.Text = "Ready to Delete...!!!"
        If (ComboBox1.SelectedItem = "DropBox") Then
            Try
                For Each selectedFileName As ListViewItem In MyCloud_ListviewTable.SelectedItems
                    Dim Del = MyDropBoxToken.Files.DeleteAsync(LbDiretorio.Text & "/" & selectedFileName.Text)
                    selectedFileName.Remove()
                    lblStatus.Text = "Successfully Delete dropbox file...!!!"
                    MsgBox("File Delete successful...")
                Next
            Catch ex As Exception

            End Try

        ElseIf (ComboBox1.SelectedItem = "Google Drive") Then
            Try
                For Each selectedFileName As ListViewItem In MyCloud_ListviewTable.SelectedItems
                    Dim myID = selectedFileName.SubItems.Item(3)
                    Console.WriteLine(myID.Text)
                    GoogleService.Files.Delete(myID.Text).Execute()
                    selectedFileName.Remove()
                    lblStatus.Text = "Successfully delete google file...!!!"
                    MsgBox("delete successful...")
                Next
            Catch ex As Exception

            End Try

        ElseIf (ComboBox1.SelectedItem = "OneDrive") Then

        End If

    End Sub
#End Region

#Region "=================== Window Items Clear ================"
    Private Sub ClearTextbox()
        lblConnectionStatus.Text = "Not Connected..."
        txtboxClientID.Enabled = True
        txtboxClientSecret.Enabled = True
        txtboxTokenKey.Enabled = True
        txtboxClientID.Text = ""
        txtboxClientSecret.Text = ""
        txtboxFileAttachPath.Text = ""
        txtboxTokenKey.Text = ""
        Label1.Text = ""
        Label2.Text = ""
        Label3.Text = ""
        MyCloud_ListviewTable.Items.Clear()
        LbDiretorio.Text = ""
        lblStatus.Text = ""
    End Sub
#End Region

#Region "***** Data GridView Table : Double Click : Action *****"
    Private Sub MyCloud_ListviewTable_DoubleClick(sender As Object, e As EventArgs) Handles MyCloud_ListviewTable.DoubleClick

        If (ComboBox1.SelectedItem = "DropBox") Then
            For Each X As ListViewItem In MyCloud_ListviewTable.SelectedItems
                On Error Resume Next
                If X.Text = "..." Then

                    MyCloud_ListviewTable.Items.Clear()

                    If Not LbDiretorio.Text.Substring(0, LbDiretorio.Text.LastIndexOf("/")) = Nothing Then
                        Dim NewItem As New ListViewItem
                        NewItem.Text = "..."
                        NewItem.ImageIndex = 2
                        MyCloud_ListviewTable.Items.Add(NewItem)
                    End If

                    LbDiretorio.Text = LbDiretorio.Text.Substring(0, LbDiretorio.Text.LastIndexOf("/"))

                    For Each Arquivos In MyDropBoxToken.Files.ListFolderAsync(LbDiretorio.Text).Result.Entries
                        Dim NewItem As New ListViewItem
                        NewItem.Text = Path.GetFileName(Arquivos.Name)
                        If Arquivos.IsFolder Then
                            NewItem.SubItems.Add("Directory")
                            NewItem.ImageIndex = 0
                        Else
                            NewItem.SubItems.Add("File")
                            NewItem.SubItems.Add(FileSize(Arquivos.AsFile.Size))
                            NewItem.ImageIndex = 1
                        End If
                        MyCloud_ListviewTable.Items.Add(NewItem)
                    Next

                Else

                    MyCloud_ListviewTable.Items.Clear()

                    Dim Voltar As New ListViewItem
                    Voltar.Text = "..."
                    Voltar.ImageIndex = 2
                    MyCloud_ListviewTable.Items.Add(Voltar)

                    LbDiretorio.Text += "/" & X.Text

                    For Each Arquivos In MyDropBoxToken.Files.ListFolderAsync(LbDiretorio.Text).Result.Entries
                        Dim NewItem As New ListViewItem
                        NewItem.Text = Path.GetFileName(Arquivos.Name)
                        If Arquivos.IsFolder Then
                            NewItem.SubItems.Add("Directory")
                            NewItem.ImageIndex = 0
                        Else
                            NewItem.SubItems.Add("File")
                            NewItem.SubItems.Add(FileSize(Arquivos.AsFile.Size))
                            NewItem.ImageIndex = 1
                        End If
                        MyCloud_ListviewTable.Items.Add(NewItem)
                    Next

                End If

            Next

        ElseIf (ComboBox1.SelectedItem = "Google Drive") Then
            For Each X As ListViewItem In MyCloud_ListviewTable.SelectedItems
                On Error Resume Next
                If X.Text = "..." Then

                    MyCloud_ListviewTable.Items.Clear()

                    If Not LbDiretorio.Text.Substring(0, LbDiretorio.Text.LastIndexOf("/")) = Nothing Then
                        Dim NewItem As New ListViewItem
                        NewItem.Text = "..."
                        NewItem.ImageIndex = 2
                        MyCloud_ListviewTable.Items.Add(NewItem)
                    End If

                    LbDiretorio.Text = LbDiretorio.Text.Substring(0, LbDiretorio.Text.LastIndexOf("/"))
                    '/////
                    Dim listRequest As FilesResource.ListRequest = GoogleService.Files.List()
                    Dim files As IList(Of Google.Apis.Drive.v3.Data.File) = listRequest.Execute().Files
                    Console.WriteLine("Files:")


                    For Each file In files
                        Dim NewItem As New ListViewItem
                        NewItem.Text = file.Name

                        If (file.MimeType = "application/vnd.google-apps.folder") Then
                            NewItem.SubItems.Add("Directory")
                            NewItem.SubItems.Add("")
                            NewItem.SubItems.Add(file.Id)
                            NewItem.ImageIndex = 0
                        Else
                            NewItem.SubItems.Add("File")
                            NewItem.SubItems.Add("")
                            NewItem.SubItems.Add(file.Id)
                            NewItem.ImageIndex = 1
                        End If
                        MyCloud_ListviewTable.Items.Add(NewItem)
                    Next


                Else

                    MyCloud_ListviewTable.Items.Clear()

                    Dim Voltar As New ListViewItem
                    Voltar.Text = "..."
                    Voltar.ImageIndex = 2
                    MyCloud_ListviewTable.Items.Add(Voltar)

                    LbDiretorio.Text += "/" & X.Text

                    'For Each Arquivos In MyDropBoxToken.Files.ListFolderAsync(LbDiretorio.Text).Result.Entries
                    '    Dim NewItem As New ListViewItem
                    '    NewItem.Text = Path.GetFileName(Arquivos.Name)
                    '    If Arquivos.IsFolder Then
                    '        NewItem.SubItems.Add("Directory")
                    '        NewItem.ImageIndex = 0
                    '    Else
                    '        NewItem.SubItems.Add("File")
                    '        NewItem.SubItems.Add(FileSize(Arquivos.AsFile.Size))
                    '        NewItem.ImageIndex = 1
                    '    End If
                    '    MyCloud_ListviewTable.Items.Add(NewItem)
                    'Next

                    'Dim listRequest As FilesResource.ListRequest = GoogleService.Files.List()
                    'Dim files As IList(Of Google.Apis.Drive.v3.Data.File) = listRequest.Execute().Files
                    'Console.WriteLine("Files:")

                    'For Each file In files
                    '    Dim NewItem As New ListViewItem
                    '    NewItem.Text = file.Name

                    '    If (file.MimeType = "application/vnd.google-apps.folder") Then
                    '        NewItem.SubItems.Add("Directory")
                    '        NewItem.ImageIndex = 0
                    '    Else
                    '        NewItem.SubItems.Add("File")
                    '        NewItem.ImageIndex = 1
                    '    End If
                    '    MyCloud_ListviewTable.Items.Add(NewItem)
                    'Next

                End If

            Next

        ElseIf (ComboBox1.SelectedItem = "OneDrive") Then
            'LoadFolderFromId 'pageCount default value is 0
            For Each X As ListViewItem In MyCloud_ListviewTable.SelectedItems
                On Error Resume Next

                If X.Text = "..." Then
                    pageCount -= 1
                    MyCloud_ListviewTable.Items.Clear()

                    If Not LbDiretorio.Text.Substring(0, LbDiretorio.Text.LastIndexOf("/")) = Nothing Then
                        Dim NewItem As New ListViewItem
                        NewItem.Text = "..."
                        NewItem.ImageIndex = 2
                        MyCloud_ListviewTable.Items.Add(NewItem)

                        If (pageCount > 0) Then
                            Console.WriteLine("Before Count: " & pageCount)

                            Console.WriteLine("After Count: " & pageCount)
                            Console.WriteLine(pageList(pageCount))
                            LoadFolderFromId(pageList(pageCount))
                            pageList.Remove(pageList(pageCount))

                            'pageList.Add(myID.Text)
                        End If

                    End If

                    LbDiretorio.Text = LbDiretorio.Text.Substring(0, LbDiretorio.Text.LastIndexOf("/"))
                    '/////
                    'Dim myID = X.SubItems.Item(3)
                    'LoadFolderFromId(myID.Text)
                    'Console.WriteLine("=====" & myID.Text)

                    If (pageCount = 0) Then
                        'pageList.Add("")
                        'pageList.Remove(pageList(pageCount))
                        Console.WriteLine(pageList(pageCount))
                        LoadFolderFromPath()
                        pageList.Clear()
                    End If

                Else

                    MyCloud_ListviewTable.Items.Clear()
                    Dim myID = X.SubItems.Item(3)

                    Dim Voltar As New ListViewItem
                    Voltar.Text = "..."
                    Voltar.ImageIndex = 2
                    Voltar.SubItems.Add("") 'directory
                    Voltar.SubItems.Add("") 'size
                    Voltar.SubItems.Add("") 'ID
                    MyCloud_ListviewTable.Items.Add(Voltar)

                    LbDiretorio.Text += "/" & X.Text
                    '....;hhugugug

                    If (pageCount = 0) Then
                        pageList.Add("") '1st
                        pageList.Add(myID.Text) '1st cat
                    End If

                    If (pageCount > 0) Then
                        pageList.Add(myID.Text) '2nd cat, 3rd cat
                    End If
                    pageCount = pageCount + 1

                    LoadFolderFromId(myID.Text)

                End If

            Next

        End If


    End Sub
#End Region

    Private Sub btnCreateNowFolder_Click(sender As Object, e As EventArgs) Handles btnCreateNowFolder.Click
        If (ComboBox1.SelectedItem = "DropBox") Then
            DropBoxNewFolder_Create()

        ElseIf (ComboBox1.SelectedItem = "Google Drive") Then


        ElseIf (ComboBox1.SelectedItem = "OneDrive") Then

        End If
    End Sub

    Private Sub DropBoxNewFolder_Create()
        Try
            Dim Create = MyDropBoxToken.Files.CreateFolderAsync(LbDiretorio.Text & "/" & txtboxFolderName.Text)

            Dim NewItem As New ListViewItem
            NewItem.Text = Path.GetFileName(Create.Result.Name)
            NewItem.SubItems.Add("Directory")
            NewItem.ImageIndex = 0
            MyCloud_ListviewTable.Items.Add(NewItem)

            lblStatus.Text = "Successfully Created NewFolder..."

        Catch ex As Exception
            lblStatus.Text = "Folder Create Fail...."

        End Try

    End Sub

End Class
