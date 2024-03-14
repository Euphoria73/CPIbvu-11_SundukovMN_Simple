namespace ProjectContainerShip
{
    partial class FormContainerShip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormContainerShip));
            pictureBoxContainerShip = new PictureBox();
            buttonCreate = new Button();
            buttonLeft = new Button();
            buttonUp = new Button();
            buttonRight = new Button();
            buttonDown = new Button();
            buttonCreateShip = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxContainerShip).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxContainerShip
            // 
            pictureBoxContainerShip.Dock = DockStyle.Fill;
            pictureBoxContainerShip.Location = new Point(0, 0);
            pictureBoxContainerShip.Name = "pictureBoxContainerShip";
            pictureBoxContainerShip.Size = new Size(689, 418);
            pictureBoxContainerShip.TabIndex = 0;
            pictureBoxContainerShip.TabStop = false;
            // 
            // buttonCreate
            // 
            buttonCreate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCreate.Location = new Point(0, 370);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.RightToLeft = RightToLeft.Yes;
            buttonCreate.Size = new Size(98, 48);
            buttonCreate.TabIndex = 1;
            buttonCreate.Text = "Создать контейнеровоз";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += ButtonCreateContainerShip_Click;
            // 
            // buttonLeft
            // 
            buttonLeft.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonLeft.BackgroundImage = (Image)resources.GetObject("buttonLeft.BackgroundImage");
            buttonLeft.BackgroundImageLayout = ImageLayout.Stretch;
            buttonLeft.Location = new Point(589, 383);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(35, 35);
            buttonLeft.TabIndex = 2;
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += ButtonMove_Click;
            // 
            // buttonUp
            // 
            buttonUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonUp.BackgroundImage = (Image)resources.GetObject("buttonUp.BackgroundImage");
            buttonUp.BackgroundImageLayout = ImageLayout.Stretch;
            buttonUp.Location = new Point(621, 351);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(35, 35);
            buttonUp.TabIndex = 3;
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += ButtonMove_Click;
            // 
            // buttonRight
            // 
            buttonRight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRight.BackgroundImage = (Image)resources.GetObject("buttonRight.BackgroundImage");
            buttonRight.BackgroundImageLayout = ImageLayout.Stretch;
            buttonRight.Location = new Point(653, 383);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(35, 35);
            buttonRight.TabIndex = 4;
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += ButtonMove_Click;
            // 
            // buttonDown
            // 
            buttonDown.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonDown.BackgroundImage = (Image)resources.GetObject("buttonDown.BackgroundImage");
            buttonDown.BackgroundImageLayout = ImageLayout.Stretch;
            buttonDown.Location = new Point(621, 383);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(35, 35);
            buttonDown.TabIndex = 5;
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += ButtonMove_Click;
            // 
            // buttonCreateShip
            // 
            buttonCreateShip.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonCreateShip.Location = new Point(104, 370);
            buttonCreateShip.Name = "buttonCreateShip";
            buttonCreateShip.RightToLeft = RightToLeft.Yes;
            buttonCreateShip.Size = new Size(98, 48);
            buttonCreateShip.TabIndex = 6;
            buttonCreateShip.Text = "Создать корабль";
            buttonCreateShip.UseVisualStyleBackColor = true;
            buttonCreateShip.Click += ButtonCreateShip_Click;
            // 
            // FormContainerShip
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 418);
            Controls.Add(buttonCreateShip);
            Controls.Add(buttonDown);
            Controls.Add(buttonRight);
            Controls.Add(buttonUp);
            Controls.Add(buttonLeft);
            Controls.Add(buttonCreate);
            Controls.Add(pictureBoxContainerShip);
            Name = "FormContainerShip";
            Text = "Контейнеровоз";
            ((System.ComponentModel.ISupportInitialize)pictureBoxContainerShip).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxContainerShip;
        private Button buttonCreate;
        private Button buttonLeft;
        private Button buttonUp;
        private Button buttonRight;
        private Button buttonDown;
        private Button buttonCreateShip;
    }
}