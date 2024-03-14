namespace NorthWind2024StarterApp;

partial class ModelsForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        ModelsComboBox = new ComboBox();
        CurrentButton = new Button();
        SuspendLayout();
        // 
        // ModelsComboBox
        // 
        ModelsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        ModelsComboBox.FormattingEnabled = true;
        ModelsComboBox.Location = new Point(24, 41);
        ModelsComboBox.Name = "ModelsComboBox";
        ModelsComboBox.Size = new Size(273, 28);
        ModelsComboBox.TabIndex = 0;
        // 
        // CurrentButton
        // 
        CurrentButton.Location = new Point(324, 40);
        CurrentButton.Name = "CurrentButton";
        CurrentButton.Size = new Size(94, 29);
        CurrentButton.TabIndex = 1;
        CurrentButton.Text = "Current";
        CurrentButton.UseVisualStyleBackColor = true;
        CurrentButton.Click += CurrentButton_Click;
        // 
        // ModelsForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(CurrentButton);
        Controls.Add(ModelsComboBox);
        Name = "ModelsForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Models";
        Load += ModelsForm_Load;
        ResumeLayout(false);
    }

    #endregion

    private ComboBox ModelsComboBox;
    private Button CurrentButton;
}