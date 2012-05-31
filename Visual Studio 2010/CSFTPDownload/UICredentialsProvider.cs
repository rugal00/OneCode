﻿/****************************** 模块头 ******************************\
* 模块名:  UICredentialsProvider.cs
* 项目名:	    CSFTPDownload
* 版权(c)  Microsoft Corporation.
* 
* 这个提供凭据界面窗体包含3个文本框接受用户名，
' 密码和域为了初始化NetworkCredential实例。
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
* EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
* WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Net;
using System.Windows.Forms;

namespace CSFTPDownload
{
    public partial class UICredentialsProvider : Form
    {
        public NetworkCredential Credentials { get; set; }

        bool useOriginalCredentials = true;

        public UICredentialsProvider()
            : this(null)
        { }

        public UICredentialsProvider(NetworkCredential credentials)
        {

            InitializeComponent();

            this.Credentials = credentials;

            if (this.Credentials != null)
            {
                this.tbUserName.Text = this.Credentials.UserName;
                this.tbDomain.Text = this.Credentials.Domain;
                this.tbPassword.Text = this.Credentials.Password;
                useOriginalCredentials = true;
            }
            else
            {
                useOriginalCredentials = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!useOriginalCredentials)
            {
                if (chkAnonymous.Checked)
                {

                    // 默认情况下使用匿名凭据.
                    Credentials = new NetworkCredential("匿名", "");
                }
                else if (String.IsNullOrWhiteSpace(tbUserName.Text)
                        || String.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    MessageBox.Show("请输入用户名和密码!");
                    return;
                }
                else
                {
                    Credentials = new NetworkCredential(
                        tbUserName.Text.Trim(),
                        tbPassword.Text,
                        tbDomain.Text.Trim());
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void chkAnonymous_CheckedChanged(object sender, EventArgs e)
        {
            tbDomain.Enabled = !chkAnonymous.Checked;
            tbPassword.Enabled = !chkAnonymous.Checked;
            tbUserName.Enabled = !chkAnonymous.Checked;

            useOriginalCredentials = false;
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            useOriginalCredentials = false;
        }

        private void UICredentialsProvider_Load(object sender, EventArgs e)
        {

        }
    }
}
