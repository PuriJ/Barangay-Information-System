<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnClearance = New System.Windows.Forms.Button()
        Me.btnPermit = New System.Windows.Forms.Button()
        Me.btnDerogatory = New System.Windows.Forms.Button()
        Me.btnIndigency = New System.Windows.Forms.Button()
        Me.btnResidency = New System.Windows.Forms.Button()
        Me.btnResidents = New System.Windows.Forms.Button()
        Me.btnAccount = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnLogs = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(150, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(922, 95)
        Me.Panel1.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(777, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(145, 95)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(146, 95)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Rockwell", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(195, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(524, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BARANGAY UNANG SIGAW"
        '
        'btnClearance
        '
        Me.btnClearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnClearance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearance.Location = New System.Drawing.Point(27, 127)
        Me.btnClearance.Name = "btnClearance"
        Me.btnClearance.Size = New System.Drawing.Size(144, 54)
        Me.btnClearance.TabIndex = 2
        Me.btnClearance.Text = "BARANGAY CLEARANCE"
        Me.btnClearance.UseVisualStyleBackColor = False
        '
        'btnPermit
        '
        Me.btnPermit.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnPermit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPermit.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPermit.Location = New System.Drawing.Point(27, 197)
        Me.btnPermit.Name = "btnPermit"
        Me.btnPermit.Size = New System.Drawing.Size(144, 58)
        Me.btnPermit.TabIndex = 3
        Me.btnPermit.Text = "BUSINESS PERMIT"
        Me.btnPermit.UseVisualStyleBackColor = False
        '
        'btnDerogatory
        '
        Me.btnDerogatory.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnDerogatory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDerogatory.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDerogatory.Location = New System.Drawing.Point(27, 271)
        Me.btnDerogatory.Name = "btnDerogatory"
        Me.btnDerogatory.Size = New System.Drawing.Size(144, 35)
        Me.btnDerogatory.TabIndex = 4
        Me.btnDerogatory.Text = "DEROGATORY"
        Me.btnDerogatory.UseVisualStyleBackColor = False
        '
        'btnIndigency
        '
        Me.btnIndigency.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnIndigency.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIndigency.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndigency.Location = New System.Drawing.Point(27, 322)
        Me.btnIndigency.Name = "btnIndigency"
        Me.btnIndigency.Size = New System.Drawing.Size(144, 35)
        Me.btnIndigency.TabIndex = 5
        Me.btnIndigency.Text = "INDIGENCY"
        Me.btnIndigency.UseVisualStyleBackColor = False
        '
        'btnResidency
        '
        Me.btnResidency.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnResidency.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResidency.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResidency.Location = New System.Drawing.Point(27, 373)
        Me.btnResidency.Name = "btnResidency"
        Me.btnResidency.Size = New System.Drawing.Size(144, 35)
        Me.btnResidency.TabIndex = 6
        Me.btnResidency.Text = "RESIDENCY"
        Me.btnResidency.UseVisualStyleBackColor = False
        '
        'btnResidents
        '
        Me.btnResidents.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnResidents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResidents.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResidents.Location = New System.Drawing.Point(27, 426)
        Me.btnResidents.Name = "btnResidents"
        Me.btnResidents.Size = New System.Drawing.Size(144, 35)
        Me.btnResidents.TabIndex = 7
        Me.btnResidents.Text = "RESIDENTS"
        Me.btnResidents.UseVisualStyleBackColor = False
        '
        'btnAccount
        '
        Me.btnAccount.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAccount.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccount.Location = New System.Drawing.Point(27, 480)
        Me.btnAccount.Name = "btnAccount"
        Me.btnAccount.Size = New System.Drawing.Size(144, 35)
        Me.btnAccount.TabIndex = 8
        Me.btnAccount.Text = "ACCOUNTS"
        Me.btnAccount.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(27, 641)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(144, 35)
        Me.btnLogout.TabIndex = 13
        Me.btnLogout.Text = "LOGOUT"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(211, 127)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(948, 565)
        Me.Panel2.TabIndex = 14
        '
        'btnLogs
        '
        Me.btnLogs.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnLogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogs.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Location = New System.Drawing.Point(27, 535)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(144, 35)
        Me.btnLogs.TabIndex = 15
        Me.btnLogs.Text = "LOGS"
        Me.btnLogs.UseVisualStyleBackColor = False
        '
        'btnReport
        '
        Me.btnReport.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReport.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.Location = New System.Drawing.Point(27, 586)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(144, 35)
        Me.btnReport.TabIndex = 16
        Me.btnReport.Text = "REPORT"
        Me.btnReport.UseVisualStyleBackColor = False
        '
        'Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkOrange
        Me.ClientSize = New System.Drawing.Size(1180, 713)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnLogs)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnResidents)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnIndigency)
        Me.Controls.Add(Me.btnAccount)
        Me.Controls.Add(Me.btnPermit)
        Me.Controls.Add(Me.btnDerogatory)
        Me.Controls.Add(Me.btnClearance)
        Me.Controls.Add(Me.btnResidency)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Admin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnClearance As Button
    Friend WithEvents btnPermit As Button
    Friend WithEvents btnDerogatory As Button
    Friend WithEvents btnIndigency As Button
    Friend WithEvents btnResidency As Button
    Friend WithEvents btnResidents As Button
    Friend WithEvents btnAccount As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnLogs As Button
    Friend WithEvents btnReport As Button
End Class
