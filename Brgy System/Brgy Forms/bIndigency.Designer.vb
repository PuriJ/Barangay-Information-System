<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class bIndigency
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(bIndigency))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cbAssist = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtMid = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLast = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.bIndig1 = New Brgy_System.bIndig()
        Me.btnUpdate = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.btnPreview = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.cbAssist)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.btnPreview)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.txtMid)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtFirst)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtLast)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(453, 556)
        Me.Panel1.TabIndex = 1
        '
        'cbAssist
        '
        Me.cbAssist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAssist.FormattingEnabled = True
        Me.cbAssist.Items.AddRange(New Object() {"MEDICAL ASSISTANCE", "FINANCIAL ASSISTANCE", "BURIAL ASSISTANCE", "EDUCATIONAL ASSISTANCE"})
        Me.cbAssist.Location = New System.Drawing.Point(116, 432)
        Me.cbAssist.Name = "cbAssist"
        Me.cbAssist.Size = New System.Drawing.Size(129, 21)
        Me.cbAssist.TabIndex = 110
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 431)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 18)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Assistance:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(160, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 24)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "INDIGENCY"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(118, 58)
        Me.txtSearch.Multiline = True
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(163, 20)
        Me.txtSearch.TabIndex = 105
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(22, 58)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(90, 20)
        Me.Label19.TabIndex = 104
        Me.Label19.Text = "Last Name:"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.GridColor = System.Drawing.Color.Blue
        Me.DataGridView1.Location = New System.Drawing.Point(21, 84)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(407, 193)
        Me.DataGridView1.TabIndex = 99
        '
        'txtMid
        '
        Me.txtMid.Enabled = False
        Me.txtMid.Location = New System.Drawing.Point(116, 390)
        Me.txtMid.Multiline = True
        Me.txtMid.Name = "txtMid"
        Me.txtMid.Size = New System.Drawing.Size(129, 21)
        Me.txtMid.TabIndex = 98
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 390)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 18)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Middle Initial:"
        '
        'txtFirst
        '
        Me.txtFirst.Enabled = False
        Me.txtFirst.Location = New System.Drawing.Point(116, 341)
        Me.txtFirst.Multiline = True
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(129, 21)
        Me.txtFirst.TabIndex = 97
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 18)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "First Name:"
        '
        'txtLast
        '
        Me.txtLast.Enabled = False
        Me.txtLast.Location = New System.Drawing.Point(116, 295)
        Me.txtLast.Multiline = True
        Me.txtLast.Name = "txtLast"
        Me.txtLast.Size = New System.Drawing.Size(129, 20)
        Me.txtLast.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 295)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 18)
        Me.Label6.TabIndex = 92
        Me.Label6.Text = "Last Name:"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(481, 12)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(455, 556)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'btnUpdate
        '
        Me.btnUpdate.Activecolor = System.Drawing.Color.CornflowerBlue
        Me.btnUpdate.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnUpdate.BorderRadius = 0
        Me.btnUpdate.ButtonText = "UPDATE"
        Me.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpdate.DisabledColor = System.Drawing.Color.Gray
        Me.btnUpdate.Iconcolor = System.Drawing.Color.Transparent
        Me.btnUpdate.Iconimage = CType(resources.GetObject("btnUpdate.Iconimage"), System.Drawing.Image)
        Me.btnUpdate.Iconimage_right = Nothing
        Me.btnUpdate.Iconimage_right_Selected = Nothing
        Me.btnUpdate.Iconimage_Selected = Nothing
        Me.btnUpdate.IconMarginLeft = 0
        Me.btnUpdate.IconMarginRight = 0
        Me.btnUpdate.IconRightVisible = True
        Me.btnUpdate.IconRightZoom = 0R
        Me.btnUpdate.IconVisible = True
        Me.btnUpdate.IconZoom = 90.0R
        Me.btnUpdate.IsTab = False
        Me.btnUpdate.Location = New System.Drawing.Point(182, 495)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Normalcolor = System.Drawing.Color.CornflowerBlue
        Me.btnUpdate.OnHovercolor = System.Drawing.Color.Gray
        Me.btnUpdate.OnHoverTextColor = System.Drawing.Color.Black
        Me.btnUpdate.selected = False
        Me.btnUpdate.Size = New System.Drawing.Size(108, 43)
        Me.btnUpdate.TabIndex = 124
        Me.btnUpdate.Text = "UPDATE"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnUpdate.Textcolor = System.Drawing.Color.Black
        Me.btnUpdate.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnPreview
        '
        Me.btnPreview.Activecolor = System.Drawing.Color.CornflowerBlue
        Me.btnPreview.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPreview.BorderRadius = 0
        Me.btnPreview.ButtonText = "PREVIEW"
        Me.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPreview.DisabledColor = System.Drawing.Color.Gray
        Me.btnPreview.Iconcolor = System.Drawing.Color.Transparent
        Me.btnPreview.Iconimage = Global.Brgy_System.My.Resources.Resources.add
        Me.btnPreview.Iconimage_right = Nothing
        Me.btnPreview.Iconimage_right_Selected = Nothing
        Me.btnPreview.Iconimage_Selected = Nothing
        Me.btnPreview.IconMarginLeft = 0
        Me.btnPreview.IconMarginRight = 0
        Me.btnPreview.IconRightVisible = True
        Me.btnPreview.IconRightZoom = 0R
        Me.btnPreview.IconVisible = True
        Me.btnPreview.IconZoom = 90.0R
        Me.btnPreview.IsTab = False
        Me.btnPreview.Location = New System.Drawing.Point(305, 495)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Normalcolor = System.Drawing.Color.CornflowerBlue
        Me.btnPreview.OnHovercolor = System.Drawing.Color.Gray
        Me.btnPreview.OnHoverTextColor = System.Drawing.Color.Black
        Me.btnPreview.selected = False
        Me.btnPreview.Size = New System.Drawing.Size(114, 43)
        Me.btnPreview.TabIndex = 86
        Me.btnPreview.Text = "PREVIEW"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPreview.Textcolor = System.Drawing.Color.Black
        Me.btnPreview.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'bIndigency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(948, 580)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "bIndigency"
        Me.Text = "bIndigency"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents btnPreview As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtMid As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFirst As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtLast As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents bIndig1 As bIndig
    Friend WithEvents Label3 As Label
    Friend WithEvents cbAssist As ComboBox
    Friend WithEvents btnUpdate As Bunifu.Framework.UI.BunifuFlatButton
End Class
