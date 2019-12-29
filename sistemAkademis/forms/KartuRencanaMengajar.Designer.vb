<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KartuRencanaMengajar
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgData = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnKelola = New System.Windows.Forms.Button()
        Me.cmbDosen = New System.Windows.Forms.ComboBox()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.RoyalBlue
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(369, 41)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Kartu Rencana Mengajar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgData)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 179)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(365, 149)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Mata Kuliah yang Diampu"
        '
        'dgData
        '
        Me.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData.Location = New System.Drawing.Point(10, 22)
        Me.dgData.Name = "dgData"
        Me.dgData.Size = New System.Drawing.Size(349, 116)
        Me.dgData.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnKelola)
        Me.GroupBox1.Controls.Add(Me.cmbDosen)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 72)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 90)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Dosen"
        '
        'btnKelola
        '
        Me.btnKelola.BackColor = System.Drawing.Color.MediumOrchid
        Me.btnKelola.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnKelola.ForeColor = System.Drawing.Color.White
        Me.btnKelola.Location = New System.Drawing.Point(9, 47)
        Me.btnKelola.Name = "btnKelola"
        Me.btnKelola.Size = New System.Drawing.Size(343, 33)
        Me.btnKelola.TabIndex = 3
        Me.btnKelola.Text = "Kelola Rencana Mengajar"
        Me.btnKelola.UseVisualStyleBackColor = False
        '
        'cmbDosen
        '
        Me.cmbDosen.FormattingEnabled = True
        Me.cmbDosen.Location = New System.Drawing.Point(9, 20)
        Me.cmbDosen.Name = "cmbDosen"
        Me.cmbDosen.Size = New System.Drawing.Size(343, 21)
        Me.cmbDosen.TabIndex = 2
        '
        'KartuRencanaMengajar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 339)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "KartuRencanaMengajar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kartu Rencana Mengajar"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgData As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnKelola As System.Windows.Forms.Button
    Friend WithEvents cmbDosen As System.Windows.Forms.ComboBox
End Class
