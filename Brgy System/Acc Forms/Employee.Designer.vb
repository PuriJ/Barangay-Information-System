<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Employee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Employee))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnResidents = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnIndigency = New System.Windows.Forms.Button()
        Me.btnPermit = New System.Windows.Forms.Button()
        Me.btnClearance = New System.Windows.Forms.Button()
        Me.btnResidency = New System.Windows.Forms.Button()
        Me.btnLogs = New System.Windows.Forms.Button()
        Me.btnDerogatory = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(214, 136)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(948, 568)
        Me.Panel2.TabIndex = 24
        '
        'btnResidents
        '
        Me.btnResidents.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnResidents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResidents.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResidents.Location = New System.Drawing.Point(18, 449)
        Me.btnResidents.Name = "btnResidents"
        Me.btnResidents.Size = New System.Drawing.Size(144, 35)
        Me.btnResidents.TabIndex = 21
        Me.btnResidents.Text = "RESIDENTS"
        Me.btnResidents.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogout.Location = New System.Drawing.Point(18, 617)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Size = New System.Drawing.Size(144, 35)
        Me.btnLogout.TabIndex = 23
        Me.btnLogout.Text = "LOGOUT"
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(113, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(922, 104)
        Me.Panel1.TabIndex = 15
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(774, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(148, 106)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(148, 105)
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
        'btnIndigency
        '
        Me.btnIndigency.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnIndigency.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIndigency.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndigency.Location = New System.Drawing.Point(18, 336)
        Me.btnIndigency.Name = "btnIndigency"
        Me.btnIndigency.Size = New System.Drawing.Size(144, 35)
        Me.btnIndigency.TabIndex = 19
        Me.btnIndigency.Text = "INDIGENCY"
        Me.btnIndigency.UseVisualStyleBackColor = False
        '
        'btnPermit
        '
        Me.btnPermit.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnPermit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPermit.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPermit.Location = New System.Drawing.Point(18, 207)
        Me.btnPermit.Name = "btnPermit"
        Me.btnPermit.Size = New System.Drawing.Size(144, 58)
        Me.btnPermit.TabIndex = 17
        Me.btnPermit.Text = "BUSINESS PERMIT"
        Me.btnPermit.UseVisualStyleBackColor = False
        '
        'btnClearance
        '
        Me.btnClearance.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnClearance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearance.Location = New System.Drawing.Point(18, 136)
        Me.btnClearance.Name = "btnClearance"
        Me.btnClearance.Size = New System.Drawing.Size(144, 54)
        Me.btnClearance.TabIndex = 16
        Me.btnClearance.Text = "BARANGAY CLEARANCE"
        Me.btnClearance.UseVisualStyleBackColor = False
        '
        'btnResidency
        '
        Me.btnResidency.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnResidency.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnResidency.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResidency.Location = New System.Drawing.Point(18, 391)
        Me.btnResidency.Name = "btnResidency"
        Me.btnResidency.Size = New System.Drawing.Size(144, 35)
        Me.btnResidency.TabIndex = 20
        Me.btnResidency.Text = "RESIDENCY"
        Me.btnResidency.UseVisualStyleBackColor = False
        '
        'btnLogs
        '
        Me.btnLogs.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnLogs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogs.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.Location = New System.Drawing.Point(18, 507)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(144, 35)
        Me.btnLogs.TabIndex = 16
        Me.btnLogs.Text = "LOGS"
        Me.btnLogs.UseVisualStyleBackColor = False
        '
        'btnDerogatory
        '
        Me.btnDerogatory.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnDerogatory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDerogatory.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDerogatory.Location = New System.Drawing.Point(18, 283)
        Me.btnDerogatory.Name = "btnDerogatory"
        Me.btnDerogatory.Size = New System.Drawing.Size(144, 35)
        Me.btnDerogatory.TabIndex = 25
        Me.btnDerogatory.Text = "DEROGATORY"
        Me.btnDerogatory.UseVisualStyleBackColor = False
        '
        'btnReport
        '
        Me.btnReport.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReport.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.Location = New System.Drawing.Point(18, 562)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(144, 35)
        Me.btnReport.TabIndex = 26
        Me.btnReport.Text = "REPORT"
        Me.btnReport.UseVisualStyleBackColor = False
        '
        'Employee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkOrange
        Me.ClientSize = New System.Drawing.Size(1180, 728)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnDerogatory)
        Me.Controls.Add(Me.btnLogs)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnResidents)
        Me.Controls.Add(Me.btnLogout)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnIndigency)
        Me.Controls.Add(Me.btnPermit)
        Me.Controls.Add(Me.btnClearance)
        Me.Controls.Add(Me.btnResidency)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Employee"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnResidents As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnIndigency As Button
    Friend WithEvents btnPermit As Button
    Friend WithEvents btnClearance As Button
    Friend WithEvents btnResidency As Button
    Friend WithEvents btnLogs As Button
    Friend WithEvents btnDerogatory As Button
    Friend WithEvents btnReport As Button
End Class
