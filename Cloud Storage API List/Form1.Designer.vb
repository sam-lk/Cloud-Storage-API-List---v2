<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnAttachFile = New System.Windows.Forms.Button()
        Me.btnUploadFile = New System.Windows.Forms.Button()
        Me.txtboxClientID = New System.Windows.Forms.TextBox()
        Me.txtboxClientSecret = New System.Windows.Forms.TextBox()
        Me.lblClientID = New System.Windows.Forms.Label()
        Me.lblClientScret = New System.Windows.Forms.Label()
        Me.txtboxFileAttachPath = New System.Windows.Forms.TextBox()
        Me.lblFilePath = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblConnectionStatus = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.lblCloudList = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblToken = New System.Windows.Forms.Label()
        Me.btnConnectToAPI = New System.Windows.Forms.Button()
        Me.txtboxTokenKey = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GList = New System.Windows.Forms.ImageList(Me.components)
        Me.MyCloud_ListviewTable = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LbDiretorio = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtboxFolderName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCreateNowFolder = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAttachFile
        '
        Me.btnAttachFile.Location = New System.Drawing.Point(529, 35)
        Me.btnAttachFile.Name = "btnAttachFile"
        Me.btnAttachFile.Size = New System.Drawing.Size(65, 23)
        Me.btnAttachFile.TabIndex = 1
        Me.btnAttachFile.Text = "Attach"
        Me.btnAttachFile.UseVisualStyleBackColor = True
        '
        'btnUploadFile
        '
        Me.btnUploadFile.Location = New System.Drawing.Point(441, 62)
        Me.btnUploadFile.Name = "btnUploadFile"
        Me.btnUploadFile.Size = New System.Drawing.Size(82, 23)
        Me.btnUploadFile.TabIndex = 2
        Me.btnUploadFile.Text = "Upload Now"
        Me.btnUploadFile.UseVisualStyleBackColor = True
        '
        'txtboxClientID
        '
        Me.txtboxClientID.Location = New System.Drawing.Point(116, 94)
        Me.txtboxClientID.Name = "txtboxClientID"
        Me.txtboxClientID.Size = New System.Drawing.Size(478, 20)
        Me.txtboxClientID.TabIndex = 3
        '
        'txtboxClientSecret
        '
        Me.txtboxClientSecret.Location = New System.Drawing.Point(116, 64)
        Me.txtboxClientSecret.Name = "txtboxClientSecret"
        Me.txtboxClientSecret.Size = New System.Drawing.Size(478, 20)
        Me.txtboxClientSecret.TabIndex = 3
        '
        'lblClientID
        '
        Me.lblClientID.AutoSize = True
        Me.lblClientID.Location = New System.Drawing.Point(54, 97)
        Me.lblClientID.Name = "lblClientID"
        Me.lblClientID.Size = New System.Drawing.Size(56, 13)
        Me.lblClientID.TabIndex = 0
        Me.lblClientID.Text = "Client ID : "
        '
        'lblClientScret
        '
        Me.lblClientScret.AutoSize = True
        Me.lblClientScret.Location = New System.Drawing.Point(34, 67)
        Me.lblClientScret.Name = "lblClientScret"
        Me.lblClientScret.Size = New System.Drawing.Size(76, 13)
        Me.lblClientScret.TabIndex = 0
        Me.lblClientScret.Text = "Client Secret : "
        '
        'txtboxFileAttachPath
        '
        Me.txtboxFileAttachPath.Location = New System.Drawing.Point(109, 36)
        Me.txtboxFileAttachPath.Name = "txtboxFileAttachPath"
        Me.txtboxFileAttachPath.ReadOnly = True
        Me.txtboxFileAttachPath.Size = New System.Drawing.Size(414, 20)
        Me.txtboxFileAttachPath.TabIndex = 3
        '
        'lblFilePath
        '
        Me.lblFilePath.AutoSize = True
        Me.lblFilePath.Location = New System.Drawing.Point(27, 40)
        Me.lblFilePath.Name = "lblFilePath"
        Me.lblFilePath.Size = New System.Drawing.Size(76, 13)
        Me.lblFilePath.TabIndex = 0
        Me.lblFilePath.Text = "File Location : "
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblConnectionStatus)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.lblCloudList)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblClientScret)
        Me.GroupBox1.Controls.Add(Me.lblToken)
        Me.GroupBox1.Controls.Add(Me.btnConnectToAPI)
        Me.GroupBox1.Controls.Add(Me.lblClientID)
        Me.GroupBox1.Controls.Add(Me.txtboxTokenKey)
        Me.GroupBox1.Controls.Add(Me.txtboxClientID)
        Me.GroupBox1.Controls.Add(Me.txtboxClientSecret)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(633, 168)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Client Details : "
        '
        'lblConnectionStatus
        '
        Me.lblConnectionStatus.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblConnectionStatus.Location = New System.Drawing.Point(116, 28)
        Me.lblConnectionStatus.Name = "lblConnectionStatus"
        Me.lblConnectionStatus.Size = New System.Drawing.Size(104, 21)
        Me.lblConnectionStatus.TabIndex = 0
        Me.lblConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Google Drive", "DropBox", "OneDrive", "Custom"})
        Me.ComboBox1.Location = New System.Drawing.Point(350, 28)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 4
        '
        'lblCloudList
        '
        Me.lblCloudList.AutoSize = True
        Me.lblCloudList.Location = New System.Drawing.Point(261, 31)
        Me.lblCloudList.Name = "lblCloudList"
        Me.lblCloudList.Size = New System.Drawing.Size(83, 13)
        Me.lblCloudList.TabIndex = 0
        Me.lblCloudList.Text = "Cloud Storage : "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(64, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Status : "
        '
        'lblToken
        '
        Me.lblToken.AutoSize = True
        Me.lblToken.Location = New System.Drawing.Point(25, 127)
        Me.lblToken.Name = "lblToken"
        Me.lblToken.Size = New System.Drawing.Size(85, 13)
        Me.lblToken.TabIndex = 0
        Me.lblToken.Text = "Access Token : "
        '
        'btnConnectToAPI
        '
        Me.btnConnectToAPI.Location = New System.Drawing.Point(502, 27)
        Me.btnConnectToAPI.Name = "btnConnectToAPI"
        Me.btnConnectToAPI.Size = New System.Drawing.Size(92, 23)
        Me.btnConnectToAPI.TabIndex = 2
        Me.btnConnectToAPI.Text = "Connect"
        Me.btnConnectToAPI.UseVisualStyleBackColor = True
        '
        'txtboxTokenKey
        '
        Me.txtboxTokenKey.Location = New System.Drawing.Point(116, 124)
        Me.txtboxTokenKey.Name = "txtboxTokenKey"
        Me.txtboxTokenKey.Size = New System.Drawing.Size(478, 20)
        Me.txtboxTokenKey.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtboxFileAttachPath)
        Me.GroupBox2.Controls.Add(Me.lblFilePath)
        Me.GroupBox2.Controls.Add(Me.btnAttachFile)
        Me.GroupBox2.Controls.Add(Me.btnUploadFile)
        Me.GroupBox2.Location = New System.Drawing.Point(19, 209)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(633, 104)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Upload Files : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(676, 444)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "------"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(869, 444)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "------"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1091, 444)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "------"
        '
        'GList
        '
        Me.GList.ImageStream = CType(resources.GetObject("GList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.GList.TransparentColor = System.Drawing.Color.Transparent
        Me.GList.Images.SetKeyName(0, ".Pasta.ico")
        Me.GList.Images.SetKeyName(1, "Not Found.png")
        Me.GList.Images.SetKeyName(2, "Voltar.png")
        '
        'MyCloud_ListviewTable
        '
        Me.MyCloud_ListviewTable.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.MyCloud_ListviewTable.ForeColor = System.Drawing.Color.Black
        Me.MyCloud_ListviewTable.FullRowSelect = True
        Me.MyCloud_ListviewTable.GridLines = True
        Me.MyCloud_ListviewTable.HideSelection = False
        Me.MyCloud_ListviewTable.Location = New System.Drawing.Point(24, 24)
        Me.MyCloud_ListviewTable.Name = "MyCloud_ListviewTable"
        Me.MyCloud_ListviewTable.Size = New System.Drawing.Size(556, 293)
        Me.MyCloud_ListviewTable.SmallImageList = Me.GList
        Me.MyCloud_ListviewTable.TabIndex = 6
        Me.MyCloud_ListviewTable.UseCompatibleStateImageBehavior = False
        Me.MyCloud_ListviewTable.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 300
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Type"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Size"
        Me.ColumnHeader3.Width = 120
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "ID"
        Me.ColumnHeader4.Width = 150
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(186, 360)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(95, 23)
        Me.btnDownload.TabIndex = 2
        Me.btnDownload.Text = "Download File"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(84, 360)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(95, 23)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Remove File"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.MyCloud_ListviewTable)
        Me.GroupBox3.Controls.Add(Me.btnDownload)
        Me.GroupBox3.Controls.Add(Me.LbDiretorio)
        Me.GroupBox3.Controls.Add(Me.btnDelete)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(679, 21)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(602, 402)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = " Files :- View / Download / Delete"
        '
        'LbDiretorio
        '
        Me.LbDiretorio.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.LbDiretorio.Location = New System.Drawing.Point(85, 324)
        Me.LbDiretorio.Name = "LbDiretorio"
        Me.LbDiretorio.Size = New System.Drawing.Size(495, 23)
        Me.LbDiretorio.TabIndex = 0
        Me.LbDiretorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 329)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Directory : "
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblStatus.Location = New System.Drawing.Point(264, 475)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(1017, 23)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(212, 480)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Status : "
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtboxFolderName)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.btnCreateNowFolder)
        Me.GroupBox4.Location = New System.Drawing.Point(19, 335)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(633, 88)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = " Create Folder : "
        '
        'txtboxFolderName
        '
        Me.txtboxFolderName.Location = New System.Drawing.Point(109, 36)
        Me.txtboxFolderName.Name = "txtboxFolderName"
        Me.txtboxFolderName.Size = New System.Drawing.Size(414, 20)
        Me.txtboxFolderName.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(27, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Folder Name : "
        '
        'btnCreateNowFolder
        '
        Me.btnCreateNowFolder.Location = New System.Drawing.Point(529, 35)
        Me.btnCreateNowFolder.Name = "btnCreateNowFolder"
        Me.btnCreateNowFolder.Size = New System.Drawing.Size(82, 23)
        Me.btnCreateNowFolder.TabIndex = 2
        Me.btnCreateNowFolder.Text = "Create Now"
        Me.btnCreateNowFolder.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 513)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Form1"
        Me.Text = "Cloud File Access"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAttachFile As Button
    Friend WithEvents btnUploadFile As Button
    Friend WithEvents txtboxClientID As TextBox
    Friend WithEvents txtboxClientSecret As TextBox
    Friend WithEvents lblClientID As Label
    Friend WithEvents lblClientScret As Label
    Friend WithEvents txtboxFileAttachPath As TextBox
    Friend WithEvents lblFilePath As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents lblCloudList As Label
    Friend WithEvents lblToken As Label
    Friend WithEvents txtboxTokenKey As TextBox
    Friend WithEvents GList As ImageList
    Friend WithEvents MyCloud_ListviewTable As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents btnDownload As Button
    Friend WithEvents btnConnectToAPI As Button
    Friend WithEvents lblConnectionStatus As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents LbDiretorio As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtboxFolderName As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnCreateNowFolder As Button
    Friend WithEvents ColumnHeader4 As ColumnHeader
End Class
