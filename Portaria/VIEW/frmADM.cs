﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portaria.VIEW
{
    public partial class frmADM : Form
    {


        // OBJ

        PALETT.Colors color = new PALETT.Colors();

        // var 

        int window_X = 0, window_Y = 0;
        bool menuAberto = false;

        // methods

        #region Methods

        private void Maximiza_Restaura_Tela ()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                this.WindowState = FormWindowState.Normal;
                ptbMaxRestore.Image = Properties.Resources.window_maximize;
            }
            else

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                ptbMaxRestore.Image = Properties.Resources.window_restore;
            }
        }

        #endregion 

        public frmADM()
        {
            InitializeComponent();
        }
        private void frmADM_Load(object sender, EventArgs e)
        {
            panTitleBar.BackColor = color.AzulTitleBar;
            panActionBar.BackColor = color.AzulActionBar;
            panSideBar.BackColor = color.AzulSideBar;
            lblAddEsp.BackColor = color.AzulBackground;
            lblCadUser.BackColor = color.AzulBackground;

            this.Opacity = 0.1;
            fadeInEffectADM.Enabled = true;
        }

        // Eventos

       #region Eventos


        private void ptbWindowClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptbWindowMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            window_X = this.Left - MousePosition.X;
            window_Y = this.Top - MousePosition.Y;
        }

        private void panTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = window_X + MousePosition.X;
            this.Top = window_Y + MousePosition.Y;
        }

        private void panTitleBar_DoubleClick(object sender, EventArgs e)
        {
            Maximiza_Restaura_Tela();
        }

        private void fadeEffectADM_Tick(object sender, EventArgs e)
        {
            if (this.Opacity <= 1.0)
            {
                this.Opacity += 0.025;
            }else
            {
                fadeInEffectADM.Enabled = false;
            }
        }

        private void rdbTipoServ_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTipoServ.Checked)
            {
                lblSIAPE.Visible = true;
                mskSIAPE.Visible = true;
                lblSenhaADM.Visible = true;
                ckbADM.Visible = true;
                txtSenhaADM.Visible = true;
            } else
            {
                lblSIAPE.Visible = false;
                mskSIAPE.Visible = false;
                lblSenhaADM.Visible = false;
                ckbADM.Visible = false;
                txtSenhaADM.Visible = false;
            }
        }

        private void rdbTipoAlluno_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTipoAlluno.Checked)
            {
                lblProntUsr.Visible = true;
                mskProntAlun.Visible = true;
                ckbADM.Visible = false;
                txtSenhaADM.Visible = false;
            }
            else
            {
                lblProntUsr.Visible = false;
                mskProntAlun.Visible = false;
                
            }
        }

        private void rdbTipoExt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTipoExt.Checked)
            {
                ckbADM.Visible = false;
                lblProntUsr.Visible = false;
                mskProntAlun.Visible = false;
                lblSIAPE.Visible = false;
                mskSIAPE.Visible = false;
                ckbADM.Visible = false;
                txtSenhaADM.Visible = false;
            }
        }

        private void ptbSideMenu_Click(object sender, EventArgs e)
        {
            tmSlideEfxMenu.Enabled = true;
        }

        private void tmSlideEfxMenu_Tick(object sender, EventArgs e)
        {
            switch (menuAberto)
            {
                case true:

                    if (panSideBar.Width > 75)
                    {
                        panSideBar.Width -= 25;
                        lblUsuarios.Text = "";
                        lblAssociacoes.Text = "";
                        lblPortarias.Text = "";
                    }
                    else
                    {
                        
                        menuAberto = false;
                        tmSlideEfxMenu.Enabled = false;
                    }
                    break;
                case false:

                    if (panSideBar.Width < 250)
                    {
                        panSideBar.Width += 25;

                    } else
                    {
                        lblUsuarios.Text = "Usuários";
                        lblAssociacoes.Text = "Associações";
                        lblPortarias.Text = "Portarias";
                        menuAberto = true;
                        tmSlideEfxMenu.Enabled = false;
                    }
                    break;
            }
        }

        private void lblUsuarios_MouseEnter(object sender, EventArgs e)
        {
            lblUsuarios.BackColor = color.AzulSideBarHighlight;
        }

        private void lblUsuarios_MouseLeave(object sender, EventArgs e)
        {
            lblUsuarios.BackColor = color.AzulSideBar;
        }

        private void lblAssociacoes_MouseEnter(object sender, EventArgs e)
        {
            lblAssociacoes.BackColor = color.AzulSideBarHighlight;
        }

        private void lblAssociacoes_MouseLeave(object sender, EventArgs e)
        {
            lblAssociacoes.BackColor = color.AzulSideBar;
        }

        private void lblPortarias_MouseEnter(object sender, EventArgs e)
        {
            lblPortarias.BackColor = color.AzulSideBarHighlight;
        }

        private void lblPortarias_MouseLeave(object sender, EventArgs e)
        {
            lblPortarias.BackColor = color.AzulSideBar;
        }

        private void ptbMaxRestore_Click(object sender, EventArgs e)
        {
            Maximiza_Restaura_Tela();
        }

       #endregion
    }
}
