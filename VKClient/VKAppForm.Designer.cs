namespace VKClient
{
    partial class VKClientForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VKClientForm));
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.buttonMakeRequest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblFunction = new System.Windows.Forms.Label();
            this.radioBtnFriends = new System.Windows.Forms.RadioButton();
            this.checkBoxSavedPhoto = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.lblCycles = new System.Windows.Forms.Label();
            this.numericUpDownCyles = new System.Windows.Forms.NumericUpDown();
            this.comboBoxFavoriets = new System.Windows.Forms.ComboBox();
            this.btnFavorietsAdd = new System.Windows.Forms.Button();
            this.btnFavorietsDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxResponse = new System.Windows.Forms.ListBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnSaveHow = new System.Windows.Forms.Button();
            this.btnAllProfiles = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCyles)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUserID.Location = new System.Drawing.Point(36, 150);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(452, 27);
            this.textBoxUserID.TabIndex = 0;
            // 
            // buttonMakeRequest
            // 
            this.buttonMakeRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMakeRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonMakeRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMakeRequest.FlatAppearance.BorderSize = 0;
            this.buttonMakeRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMakeRequest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMakeRequest.Location = new System.Drawing.Point(525, 150);
            this.buttonMakeRequest.Name = "buttonMakeRequest";
            this.buttonMakeRequest.Size = new System.Drawing.Size(220, 27);
            this.buttonMakeRequest.TabIndex = 1;
            this.buttonMakeRequest.Text = "Сделать запрос";
            this.buttonMakeRequest.UseVisualStyleBackColor = false;
            this.buttonMakeRequest.Click += new System.EventHandler(this.buttonMakeRequest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ссылка на пользователя";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(528, 371);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(173, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpen.Location = new System.Drawing.Point(528, 333);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(217, 35);
            this.btnOpen.TabIndex = 6;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblFunction
            // 
            this.lblFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFunction.AutoSize = true;
            this.lblFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFunction.Location = new System.Drawing.Point(524, 197);
            this.lblFunction.Name = "lblFunction";
            this.lblFunction.Size = new System.Drawing.Size(82, 20);
            this.lblFunction.TabIndex = 7;
            this.lblFunction.Text = "Функция";
            // 
            // radioBtnFriends
            // 
            this.radioBtnFriends.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnFriends.AutoSize = true;
            this.radioBtnFriends.Checked = true;
            this.radioBtnFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioBtnFriends.Location = new System.Drawing.Point(528, 234);
            this.radioBtnFriends.Name = "radioBtnFriends";
            this.radioBtnFriends.Size = new System.Drawing.Size(90, 24);
            this.radioBtnFriends.TabIndex = 8;
            this.radioBtnFriends.TabStop = true;
            this.radioBtnFriends.Text = "Друзья";
            this.radioBtnFriends.UseVisualStyleBackColor = true;
            // 
            // checkBoxSavedPhoto
            // 
            this.checkBoxSavedPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSavedPhoto.AutoSize = true;
            this.checkBoxSavedPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSavedPhoto.Location = new System.Drawing.Point(553, 264);
            this.checkBoxSavedPhoto.Name = "checkBoxSavedPhoto";
            this.checkBoxSavedPhoto.Size = new System.Drawing.Size(163, 24);
            this.checkBoxSavedPhoto.TabIndex = 9;
            this.checkBoxSavedPhoto.Text = "с сохраненками";
            this.checkBoxSavedPhoto.UseVisualStyleBackColor = true;
            this.checkBoxSavedPhoto.CheckedChanged += new System.EventHandler(this.checkBoxSavedPhoto_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.Location = new System.Drawing.Point(36, 578);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(216, 34);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCompare.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompare.FlatAppearance.BorderSize = 0;
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCompare.Location = new System.Drawing.Point(528, 453);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(217, 35);
            this.btnCompare.TabIndex = 11;
            this.btnCompare.Text = "Сравнить";
            this.btnCompare.UseVisualStyleBackColor = false;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // lblCycles
            // 
            this.lblCycles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCycles.AutoSize = true;
            this.lblCycles.Enabled = false;
            this.lblCycles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCycles.Location = new System.Drawing.Point(553, 295);
            this.lblCycles.Name = "lblCycles";
            this.lblCycles.Size = new System.Drawing.Size(56, 18);
            this.lblCycles.TabIndex = 12;
            this.lblCycles.Text = "циклы:";
            // 
            // numericUpDownCyles
            // 
            this.numericUpDownCyles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCyles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDownCyles.Enabled = false;
            this.numericUpDownCyles.Location = new System.Drawing.Point(616, 295);
            this.numericUpDownCyles.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCyles.Name = "numericUpDownCyles";
            this.numericUpDownCyles.Size = new System.Drawing.Size(100, 22);
            this.numericUpDownCyles.TabIndex = 13;
            this.numericUpDownCyles.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBoxFavoriets
            // 
            this.comboBoxFavoriets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFavoriets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxFavoriets.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxFavoriets.FormattingEnabled = true;
            this.comboBoxFavoriets.Location = new System.Drawing.Point(36, 61);
            this.comboBoxFavoriets.Name = "comboBoxFavoriets";
            this.comboBoxFavoriets.Size = new System.Drawing.Size(452, 26);
            this.comboBoxFavoriets.TabIndex = 14;
            this.comboBoxFavoriets.Text = "Список избранных";
            this.comboBoxFavoriets.SelectedIndexChanged += new System.EventHandler(this.comboBoxFavoriets_SelectedIndexChanged);
            // 
            // btnFavorietsAdd
            // 
            this.btnFavorietsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFavorietsAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFavorietsAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFavorietsAdd.FlatAppearance.BorderSize = 0;
            this.btnFavorietsAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorietsAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFavorietsAdd.Location = new System.Drawing.Point(525, 38);
            this.btnFavorietsAdd.Name = "btnFavorietsAdd";
            this.btnFavorietsAdd.Size = new System.Drawing.Size(217, 36);
            this.btnFavorietsAdd.TabIndex = 16;
            this.btnFavorietsAdd.Text = "Добавить";
            this.btnFavorietsAdd.UseVisualStyleBackColor = false;
            this.btnFavorietsAdd.Click += new System.EventHandler(this.btnFavorietsAdd_Click);
            // 
            // btnFavorietsDelete
            // 
            this.btnFavorietsDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFavorietsDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFavorietsDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFavorietsDelete.FlatAppearance.BorderSize = 0;
            this.btnFavorietsDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFavorietsDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFavorietsDelete.Location = new System.Drawing.Point(525, 80);
            this.btnFavorietsDelete.Name = "btnFavorietsDelete";
            this.btnFavorietsDelete.Size = new System.Drawing.Size(217, 38);
            this.btnFavorietsDelete.TabIndex = 17;
            this.btnFavorietsDelete.Text = "Удалить";
            this.btnFavorietsDelete.UseVisualStyleBackColor = false;
            this.btnFavorietsDelete.Click += new System.EventHandler(this.btnFavorietsDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Избранное";
            // 
            // listBoxResponse
            // 
            this.listBoxResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResponse.FormattingEnabled = true;
            this.listBoxResponse.ItemHeight = 16;
            this.listBoxResponse.Location = new System.Drawing.Point(36, 197);
            this.listBoxResponse.Name = "listBoxResponse";
            this.listBoxResponse.Size = new System.Drawing.Size(452, 372);
            this.listBoxResponse.TabIndex = 19;
            this.listBoxResponse.DoubleClick += new System.EventHandler(this.listBoxResponse_DoubleClick);
            // 
            // btnProfile
            // 
            this.btnProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnProfile.Location = new System.Drawing.Point(528, 494);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(107, 64);
            this.btnProfile.TabIndex = 20;
            this.btnProfile.Text = "Профиль";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnSaveHow
            // 
            this.btnSaveHow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveHow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSaveHow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveHow.FlatAppearance.BorderSize = 0;
            this.btnSaveHow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveHow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveHow.Location = new System.Drawing.Point(707, 371);
            this.btnSaveHow.Name = "btnSaveHow";
            this.btnSaveHow.Size = new System.Drawing.Size(38, 35);
            this.btnSaveHow.TabIndex = 21;
            this.btnSaveHow.Text = "...";
            this.btnSaveHow.UseVisualStyleBackColor = false;
            this.btnSaveHow.Click += new System.EventHandler(this.btnSaveHow_Click);
            // 
            // btnAllProfiles
            // 
            this.btnAllProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllProfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAllProfiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllProfiles.FlatAppearance.BorderSize = 0;
            this.btnAllProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllProfiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAllProfiles.Location = new System.Drawing.Point(641, 494);
            this.btnAllProfiles.Name = "btnAllProfiles";
            this.btnAllProfiles.Size = new System.Drawing.Size(104, 64);
            this.btnAllProfiles.TabIndex = 22;
            this.btnAllProfiles.Text = "Все профили";
            this.btnAllProfiles.UseVisualStyleBackColor = false;
            this.btnAllProfiles.Click += new System.EventHandler(this.btnAllProfiles_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(258, 578);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(229, 34);
            this.progressBar.TabIndex = 23;
            // 
            // VKClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 634);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnAllProfiles);
            this.Controls.Add(this.btnSaveHow);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.listBoxResponse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnFavorietsDelete);
            this.Controls.Add(this.btnFavorietsAdd);
            this.Controls.Add(this.comboBoxFavoriets);
            this.Controls.Add(this.numericUpDownCyles);
            this.Controls.Add(this.lblCycles);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.checkBoxSavedPhoto);
            this.Controls.Add(this.radioBtnFriends);
            this.Controls.Add(this.lblFunction);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMakeRequest);
            this.Controls.Add(this.textBoxUserID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VKClientForm";
            this.Text = "VKApp";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCyles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Button buttonMakeRequest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblFunction;
        private System.Windows.Forms.RadioButton radioBtnFriends;
        private System.Windows.Forms.CheckBox checkBoxSavedPhoto;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Label lblCycles;
        private System.Windows.Forms.NumericUpDown numericUpDownCyles;
        private System.Windows.Forms.ComboBox comboBoxFavoriets;
        private System.Windows.Forms.Button btnFavorietsAdd;
        private System.Windows.Forms.Button btnFavorietsDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxResponse;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnSaveHow;
        private System.Windows.Forms.Button btnAllProfiles;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

