namespace kyusAPTB
{
    partial class Pokedex
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
            this.leaveButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.pokedexButton = new System.Windows.Forms.Button();
            this.teamBuilderButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pokemonGroupBox = new System.Windows.Forms.GroupBox();
            this.normalBox = new System.Windows.Forms.TextBox();
            this.immunitiesBox = new System.Windows.Forms.TextBox();
            this.resistancesBox = new System.Windows.Forms.TextBox();
            this.weaknessesBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.TextBox();
            this.SpDef = new System.Windows.Forms.TextBox();
            this.SpAtk = new System.Windows.Forms.TextBox();
            this.Def = new System.Windows.Forms.TextBox();
            this.Atk = new System.Windows.Forms.TextBox();
            this.HP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hiddenAbilityBox = new System.Windows.Forms.TextBox();
            this.ability2Box = new System.Windows.Forms.TextBox();
            this.ability1Box = new System.Windows.Forms.TextBox();
            this.weightBox = new System.Windows.Forms.TextBox();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.speciesBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.type2Box = new System.Windows.Forms.TextBox();
            this.type1Box = new System.Windows.Forms.TextBox();
            this.pokemonPictureBox = new System.Windows.Forms.PictureBox();
            this.line2 = new System.Windows.Forms.Label();
            this.line1 = new System.Windows.Forms.Label();
            this.pokemonListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pokemonGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // leaveButton
            // 
            this.leaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.leaveButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.leaveButton.FlatAppearance.BorderSize = 2;
            this.leaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.leaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.leaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveButton.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.leaveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.leaveButton.Location = new System.Drawing.Point(860, 756);
            this.leaveButton.Name = "leaveButton";
            this.leaveButton.Size = new System.Drawing.Size(120, 32);
            this.leaveButton.TabIndex = 10;
            this.leaveButton.Text = "[X] EXIT";
            this.leaveButton.UseVisualStyleBackColor = false;
            this.leaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // homeButton
            // 
            this.homeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.homeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.homeButton.FlatAppearance.BorderSize = 2;
            this.homeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.homeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(80)))));
            this.homeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeButton.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.homeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.homeButton.Location = new System.Drawing.Point(20, 30);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(160, 32);
            this.homeButton.TabIndex = 6;
            this.homeButton.Text = "[H] HOME";
            this.homeButton.UseVisualStyleBackColor = false;
            this.homeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // pokedexButton
            // 
            this.pokedexButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.pokedexButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.pokedexButton.FlatAppearance.BorderSize = 2;
            this.pokedexButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.pokedexButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(80)))));
            this.pokedexButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pokedexButton.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.pokedexButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.pokedexButton.Location = new System.Drawing.Point(20, 68);
            this.pokedexButton.Name = "pokedexButton";
            this.pokedexButton.Size = new System.Drawing.Size(160, 32);
            this.pokedexButton.TabIndex = 7;
            this.pokedexButton.Text = "[P] POKEDEX";
            this.pokedexButton.UseVisualStyleBackColor = false;
            // 
            // teamBuilderButton
            // 
            this.teamBuilderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.teamBuilderButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.teamBuilderButton.FlatAppearance.BorderSize = 2;
            this.teamBuilderButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(150)))));
            this.teamBuilderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(80)))));
            this.teamBuilderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.teamBuilderButton.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.teamBuilderButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.teamBuilderButton.Location = new System.Drawing.Point(20, 106);
            this.teamBuilderButton.Name = "teamBuilderButton";
            this.teamBuilderButton.Size = new System.Drawing.Size(160, 32);
            this.teamBuilderButton.TabIndex = 8;
            this.teamBuilderButton.Text = "[T] TEAMBUILDER";
            this.teamBuilderButton.UseVisualStyleBackColor = false;
            this.teamBuilderButton.Click += new System.EventHandler(this.TeamBuilderButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Consolas", 13F);
            this.searchTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.searchTextBox.Location = new System.Drawing.Point(197, 52);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(780, 28);
            this.searchTextBox.TabIndex = 12;
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // pokemonGroupBox
            // 
            this.pokemonGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(20)))));
            this.pokemonGroupBox.Controls.Add(this.normalBox);
            this.pokemonGroupBox.Controls.Add(this.immunitiesBox);
            this.pokemonGroupBox.Controls.Add(this.resistancesBox);
            this.pokemonGroupBox.Controls.Add(this.weaknessesBox);
            this.pokemonGroupBox.Controls.Add(this.label15);
            this.pokemonGroupBox.Controls.Add(this.label14);
            this.pokemonGroupBox.Controls.Add(this.label13);
            this.pokemonGroupBox.Controls.Add(this.label12);
            this.pokemonGroupBox.Controls.Add(this.description);
            this.pokemonGroupBox.Controls.Add(this.label11);
            this.pokemonGroupBox.Controls.Add(this.label10);
            this.pokemonGroupBox.Controls.Add(this.Speed);
            this.pokemonGroupBox.Controls.Add(this.SpDef);
            this.pokemonGroupBox.Controls.Add(this.SpAtk);
            this.pokemonGroupBox.Controls.Add(this.Def);
            this.pokemonGroupBox.Controls.Add(this.Atk);
            this.pokemonGroupBox.Controls.Add(this.HP);
            this.pokemonGroupBox.Controls.Add(this.label9);
            this.pokemonGroupBox.Controls.Add(this.label8);
            this.pokemonGroupBox.Controls.Add(this.label7);
            this.pokemonGroupBox.Controls.Add(this.label2);
            this.pokemonGroupBox.Controls.Add(this.hiddenAbilityBox);
            this.pokemonGroupBox.Controls.Add(this.ability2Box);
            this.pokemonGroupBox.Controls.Add(this.ability1Box);
            this.pokemonGroupBox.Controls.Add(this.weightBox);
            this.pokemonGroupBox.Controls.Add(this.heightBox);
            this.pokemonGroupBox.Controls.Add(this.speciesBox);
            this.pokemonGroupBox.Controls.Add(this.label6);
            this.pokemonGroupBox.Controls.Add(this.label5);
            this.pokemonGroupBox.Controls.Add(this.label4);
            this.pokemonGroupBox.Controls.Add(this.label3);
            this.pokemonGroupBox.Controls.Add(this.type2Box);
            this.pokemonGroupBox.Controls.Add(this.type1Box);
            this.pokemonGroupBox.Controls.Add(this.pokemonPictureBox);
            this.pokemonGroupBox.Controls.Add(this.line2);
            this.pokemonGroupBox.Controls.Add(this.line1);
            this.pokemonGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pokemonGroupBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.pokemonGroupBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.pokemonGroupBox.Location = new System.Drawing.Point(200, 100);
            this.pokemonGroupBox.Name = "pokemonGroupBox";
            this.pokemonGroupBox.Size = new System.Drawing.Size(780, 650);
            this.pokemonGroupBox.TabIndex = 14;
            this.pokemonGroupBox.TabStop = false;
            this.pokemonGroupBox.Text = "> POKEMON";
            this.pokemonGroupBox.Enter += new System.EventHandler(this.PokemonGroupBox_Enter);
            // 
            // normalBox
            // 
            this.normalBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.normalBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.normalBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.normalBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.normalBox.Location = new System.Drawing.Point(130, 595);
            this.normalBox.Name = "normalBox";
            this.normalBox.ReadOnly = true;
            this.normalBox.Size = new System.Drawing.Size(630, 25);
            this.normalBox.TabIndex = 34;
            // 
            // immunitiesBox
            // 
            this.immunitiesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.immunitiesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.immunitiesBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.immunitiesBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.immunitiesBox.Location = new System.Drawing.Point(130, 563);
            this.immunitiesBox.Name = "immunitiesBox";
            this.immunitiesBox.ReadOnly = true;
            this.immunitiesBox.Size = new System.Drawing.Size(630, 25);
            this.immunitiesBox.TabIndex = 33;
            // 
            // resistancesBox
            // 
            this.resistancesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.resistancesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resistancesBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.resistancesBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.resistancesBox.Location = new System.Drawing.Point(130, 531);
            this.resistancesBox.Name = "resistancesBox";
            this.resistancesBox.ReadOnly = true;
            this.resistancesBox.Size = new System.Drawing.Size(630, 25);
            this.resistancesBox.TabIndex = 32;
            // 
            // weaknessesBox
            // 
            this.weaknessesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.weaknessesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weaknessesBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.weaknessesBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.weaknessesBox.Location = new System.Drawing.Point(130, 499);
            this.weaknessesBox.Name = "weaknessesBox";
            this.weaknessesBox.ReadOnly = true;
            this.weaknessesBox.Size = new System.Drawing.Size(630, 25);
            this.weaknessesBox.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.label15.Location = new System.Drawing.Point(12, 598);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 17);
            this.label15.TabIndex = 30;
            this.label15.Text = "[1x] NORMAL";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
            this.label14.Location = new System.Drawing.Point(12, 566);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 17);
            this.label14.TabIndex = 29;
            this.label14.Text = "[0x] IMMUNE";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.label13.Location = new System.Drawing.Point(12, 534);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "[0.5x] RESIST";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label12.Location = new System.Drawing.Point(12, 502);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "[2x] WEAK";
            // 
            // description
            // 
            this.description.Font = new System.Drawing.Font("Consolas", 10F);
            this.description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.description.Location = new System.Drawing.Point(12, 165);
            this.description.MaximumSize = new System.Drawing.Size(500, 0);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(500, 0);
            this.description.TabIndex = 26;
            this.description.Text = "> No description available.";
            this.description.Click += new System.EventHandler(this.Description_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Consolas", 10F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label11.Location = new System.Drawing.Point(12, 424);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 17);
            this.label11.TabIndex = 25;
            this.label11.Text = "SPEED";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Consolas", 10F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label10.Location = new System.Drawing.Point(12, 392);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "SPDEF";
            // 
            // Speed
            // 
            this.Speed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.Speed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Speed.Font = new System.Drawing.Font("Consolas", 12F);
            this.Speed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.Speed.Location = new System.Drawing.Point(130, 420);
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            this.Speed.Size = new System.Drawing.Size(100, 26);
            this.Speed.TabIndex = 23;
            // 
            // SpDef
            // 
            this.SpDef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.SpDef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpDef.Font = new System.Drawing.Font("Consolas", 12F);
            this.SpDef.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.SpDef.Location = new System.Drawing.Point(130, 388);
            this.SpDef.Name = "SpDef";
            this.SpDef.ReadOnly = true;
            this.SpDef.Size = new System.Drawing.Size(100, 26);
            this.SpDef.TabIndex = 22;
            // 
            // SpAtk
            // 
            this.SpAtk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.SpAtk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpAtk.Font = new System.Drawing.Font("Consolas", 12F);
            this.SpAtk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.SpAtk.Location = new System.Drawing.Point(130, 356);
            this.SpAtk.Name = "SpAtk";
            this.SpAtk.ReadOnly = true;
            this.SpAtk.Size = new System.Drawing.Size(100, 26);
            this.SpAtk.TabIndex = 21;
            // 
            // Def
            // 
            this.Def.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.Def.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Def.Font = new System.Drawing.Font("Consolas", 12F);
            this.Def.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.Def.Location = new System.Drawing.Point(130, 324);
            this.Def.Name = "Def";
            this.Def.ReadOnly = true;
            this.Def.Size = new System.Drawing.Size(100, 26);
            this.Def.TabIndex = 20;
            // 
            // Atk
            // 
            this.Atk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.Atk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Atk.Font = new System.Drawing.Font("Consolas", 12F);
            this.Atk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.Atk.Location = new System.Drawing.Point(130, 292);
            this.Atk.Name = "Atk";
            this.Atk.ReadOnly = true;
            this.Atk.Size = new System.Drawing.Size(100, 26);
            this.Atk.TabIndex = 19;
            // 
            // HP
            // 
            this.HP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.HP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HP.Font = new System.Drawing.Font("Consolas", 12F);
            this.HP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.HP.Location = new System.Drawing.Point(130, 260);
            this.HP.Name = "HP";
            this.HP.ReadOnly = true;
            this.HP.Size = new System.Drawing.Size(100, 26);
            this.HP.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Consolas", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label9.Location = new System.Drawing.Point(12, 360);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "SPATK";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label8.Location = new System.Drawing.Point(12, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "DEF";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Consolas", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label7.Location = new System.Drawing.Point(12, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "ATK";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label2.Location = new System.Drawing.Point(12, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "HP";
            // 
            // hiddenAbilityBox
            // 
            this.hiddenAbilityBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.hiddenAbilityBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hiddenAbilityBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.hiddenAbilityBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.hiddenAbilityBox.Location = new System.Drawing.Point(81, 202);
            this.hiddenAbilityBox.Name = "hiddenAbilityBox";
            this.hiddenAbilityBox.ReadOnly = true;
            this.hiddenAbilityBox.Size = new System.Drawing.Size(180, 25);
            this.hiddenAbilityBox.TabIndex = 13;
            // 
            // ability2Box
            // 
            this.ability2Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.ability2Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ability2Box.Font = new System.Drawing.Font("Consolas", 11F);
            this.ability2Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.ability2Box.Location = new System.Drawing.Point(81, 171);
            this.ability2Box.Name = "ability2Box";
            this.ability2Box.ReadOnly = true;
            this.ability2Box.Size = new System.Drawing.Size(180, 25);
            this.ability2Box.TabIndex = 12;
            // 
            // ability1Box
            // 
            this.ability1Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.ability1Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ability1Box.Font = new System.Drawing.Font("Consolas", 11F);
            this.ability1Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.ability1Box.Location = new System.Drawing.Point(81, 140);
            this.ability1Box.Name = "ability1Box";
            this.ability1Box.ReadOnly = true;
            this.ability1Box.Size = new System.Drawing.Size(180, 25);
            this.ability1Box.TabIndex = 11;
            // 
            // weightBox
            // 
            this.weightBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.weightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weightBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.weightBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.weightBox.Location = new System.Drawing.Point(81, 109);
            this.weightBox.Name = "weightBox";
            this.weightBox.ReadOnly = true;
            this.weightBox.Size = new System.Drawing.Size(180, 25);
            this.weightBox.TabIndex = 10;
            // 
            // heightBox
            // 
            this.heightBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.heightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heightBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.heightBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.heightBox.Location = new System.Drawing.Point(81, 77);
            this.heightBox.Name = "heightBox";
            this.heightBox.ReadOnly = true;
            this.heightBox.Size = new System.Drawing.Size(180, 25);
            this.heightBox.TabIndex = 9;
            // 
            // speciesBox
            // 
            this.speciesBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.speciesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speciesBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.speciesBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.speciesBox.Location = new System.Drawing.Point(81, 45);
            this.speciesBox.Name = "speciesBox";
            this.speciesBox.ReadOnly = true;
            this.speciesBox.Size = new System.Drawing.Size(180, 25);
            this.speciesBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label6.Location = new System.Drawing.Point(11, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "ABIL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label5.Location = new System.Drawing.Point(11, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "WEIGHT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label4.Location = new System.Drawing.Point(11, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "HEIGHT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(220)))), ((int)(((byte)(200)))));
            this.label3.Location = new System.Drawing.Point(11, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "SPECIES";
            // 
            // type2Box
            // 
            this.type2Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.type2Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.type2Box.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.type2Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.type2Box.Location = new System.Drawing.Point(650, 305);
            this.type2Box.Name = "type2Box";
            this.type2Box.ReadOnly = true;
            this.type2Box.Size = new System.Drawing.Size(120, 26);
            this.type2Box.TabIndex = 2;
            this.type2Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // type1Box
            // 
            this.type1Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.type1Box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.type1Box.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.type1Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.type1Box.Location = new System.Drawing.Point(510, 305);
            this.type1Box.Name = "type1Box";
            this.type1Box.ReadOnly = true;
            this.type1Box.Size = new System.Drawing.Size(120, 26);
            this.type1Box.TabIndex = 1;
            this.type1Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pokemonPictureBox
            // 
            this.pokemonPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(30)))));
            this.pokemonPictureBox.Location = new System.Drawing.Point(510, 45);
            this.pokemonPictureBox.Name = "pokemonPictureBox";
            this.pokemonPictureBox.Size = new System.Drawing.Size(260, 254);
            this.pokemonPictureBox.TabIndex = 0;
            this.pokemonPictureBox.TabStop = false;
            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.line2.Location = new System.Drawing.Point(10, 637);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(760, 1);
            this.line2.TabIndex = 36;
            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.line1.Location = new System.Drawing.Point(10, 30);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(760, 1);
            this.line1.TabIndex = 35;
            // 
            // pokemonListBox
            // 
            this.pokemonListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(35)))));
            this.pokemonListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pokemonListBox.Font = new System.Drawing.Font("Consolas", 11F);
            this.pokemonListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.pokemonListBox.ItemHeight = 18;
            this.pokemonListBox.Location = new System.Drawing.Point(20, 144);
            this.pokemonListBox.Name = "pokemonListBox";
            this.pokemonListBox.Size = new System.Drawing.Size(160, 632);
            this.pokemonListBox.TabIndex = 15;
            this.pokemonListBox.SelectedIndexChanged += new System.EventHandler(this.PokemonListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 11F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(197, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "[ SEARCH ] >";
            // 
            // Pokedex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(10)))));
            this.ClientSize = new System.Drawing.Size(1000, 800);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pokemonListBox);
            this.Controls.Add(this.pokemonGroupBox);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.leaveButton);
            this.Controls.Add(this.teamBuilderButton);
            this.Controls.Add(this.pokedexButton);
            this.Controls.Add(this.homeButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "Pokedex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "kyusAPTB - Pokedex";
            this.Load += new System.EventHandler(this.Pokedex_Load);
            this.pokemonGroupBox.ResumeLayout(false);
            this.pokemonGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button leaveButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button pokedexButton;
        private System.Windows.Forms.Button teamBuilderButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox pokemonGroupBox;
        private System.Windows.Forms.ListBox pokemonListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pokemonPictureBox;
        private System.Windows.Forms.TextBox type2Box;
        private System.Windows.Forms.TextBox type1Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hiddenAbilityBox;
        private System.Windows.Forms.TextBox ability2Box;
        private System.Windows.Forms.TextBox ability1Box;
        private System.Windows.Forms.TextBox weightBox;
        private System.Windows.Forms.TextBox heightBox;
        private System.Windows.Forms.TextBox speciesBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Speed;
        private System.Windows.Forms.TextBox SpDef;
        private System.Windows.Forms.TextBox SpAtk;
        private System.Windows.Forms.TextBox Def;
        private System.Windows.Forms.TextBox Atk;
        private System.Windows.Forms.TextBox HP;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.TextBox normalBox;
        private System.Windows.Forms.TextBox immunitiesBox;
        private System.Windows.Forms.TextBox resistancesBox;
        private System.Windows.Forms.TextBox weaknessesBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label line1;
        private System.Windows.Forms.Label line2;
    }
}