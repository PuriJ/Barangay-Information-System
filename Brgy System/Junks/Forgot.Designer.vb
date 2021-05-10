<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Forgot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Forgot))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLogin = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.txtUsern = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel1.Controls.Add(Me.BunifuThinButton21)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtUsern)
        Me.Panel1.Controls.Add(Me.btnLogin)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(500, 320)
        Me.Panel1.TabIndex = 0
        '
        'btnLogin
        '
        Me.btnLogin.ActiveBorderThickness = 1
        Me.btnLogin.ActiveCornerRadius = 20
        Me.btnLogin.ActiveFillColor = System.Drawing.Color.DeepSkyBlue
        Me.btnLogin.ActiveForecolor = System.Drawing.SystemColors.Control
        Me.btnLogin.ActiveLineColor = System.Drawing.Color.DeepSkyBlue
        Me.btnLogin.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.btnLogin.BackColor = System.Drawing.SystemColors.ControlDark
        Me.btnLogin.BackgroundImage = CType(resources.GetObject("btnLogin.BackgroundImage"), System.Drawing.Image)
        Me.btnLogin.ButtonText = "BACK"
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLogin.IdleBorderThickness = 2
        Me.btnLogin.IdleCornerRadius = 20
        Me.btnLogin.IdleFillColor = System.Drawing.Color.DeepSkyBlue
        Me.btnLogin.IdleForecolor = System.Drawing.SystemColors.ControlText
        Me.btnLogin.IdleLineColor = System.Drawing.SystemColors.ControlText
        Me.btnLogin.Location = New System.Drawing.Point(4, 5)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnLogin.Size = New System.Drawing.Size(108, 48)
        Me.btnLogin.TabIndex = 9
        Me.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtUsern
        '
        Me.txtUsern.Location = New System.Drawing.Point(127, 100)
        Me.txtUsern.Multiline = True
        Me.txtUsern.Name = "txtUsern"
        Me.txtUsern.Size = New System.Drawing.Size(252, 26)
        Me.txtUsern.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(149, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(214, 18)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "ENTER YOUR USERNAME"
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.DeepSkyBlue
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.SystemColors.Control
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.DeepSkyBlue
        Me.BunifuThinButton21.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BunifuThinButton21.BackColor = System.Drawing.SystemColors.ControlDark
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "PROCEED"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BunifuThinButton21.IdleBorderThickness = 2
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.DeepSkyBlue
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.SystemColors.ControlText
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.SystemColors.ControlText
        Me.BunifuThinButton21.Location = New System.Drawing.Point(191, 164)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BunifuThinButton21.Size = New System.Drawing.Size(108, 48)
        Me.BunifuThinButton21.TabIndex = 12
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Forgot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkOrange
        Me.ClientSize = New System.Drawing.Size(524, 344)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Forgot"
        Me.Text = "Forgot"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Private WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUsern As TextBox
    Private WithEvents btnLogin As Bunifu.Framework.UI.BunifuThinButton2
End Class
