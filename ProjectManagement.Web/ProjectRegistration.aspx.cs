using ProjectManagement.Models;
using ProjectManagement.WCF;
using System;
using System.Globalization;
using System.ServiceModel;
using System.Web.UI;

namespace ProjectManagement.Web
{
    public partial class ProjectRegistration : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearMessage();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateFields())
                    return;

                var project = CreateProject();

                bool success = RegisterProjectInService(project);

                if (success)
                {
                    ShowSuccessMessage("Projeto cadastrado com sucesso!");
                    ClearFields();
                }
                else
                {
                    ShowErrorMessage("Não foi possível cadastrar o projeto. Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao cadastrar projeto: {ex.Message}");
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            ClearMessage();
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtNumeroProjeto.Text))
            {
                ShowErrorMessage("O campo 'Número do Projeto' é obrigatório.");
                txtNumeroProjeto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroSubprojeto.Text))
            {
                ShowErrorMessage("O campo 'Número do Subprojeto' é obrigatório.");
                txtNumeroSubprojeto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNomeProjeto.Text))
            {
                ShowErrorMessage("O campo 'Nome do Projeto' é obrigatório.");
                txtNomeProjeto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNomeCoordenador.Text))
            {
                ShowErrorMessage("O campo 'Nome do Coordenador' é obrigatório.");
                txtNomeCoordenador.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSaldo.Text))
            {
                ShowErrorMessage("O campo 'Saldo do Projeto' é obrigatório.");
                txtSaldo.Focus();
                return false;
            }

            decimal balance;
            if (!decimal.TryParse(txtSaldo.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out balance))
            {
                ShowErrorMessage("O campo 'Saldo do Projeto' deve ser um valor numérico válido. Use ponto ou vírgula como separador decimal.");
                txtSaldo.Focus();
                return false;
            }

            if (balance < 0)
            {
                ShowErrorMessage("O saldo do projeto não pode ser negativo.");
                txtSaldo.Focus();
                return false;
            }

            return true;
        }

        private Project CreateProject()
        {
            decimal balance = decimal.Parse(txtSaldo.Text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture);

            return new Project
            {
                ProjectNumber = txtNumeroProjeto.Text.Trim(),
                SubprojectNumber = txtNumeroSubprojeto.Text.Trim(),
                ProjectName = txtNomeProjeto.Text.Trim(),
                CoodinatorName = txtNomeCoordenador.Text.Trim(),
                Balance = balance
            };
        }

        private bool RegisterProjectInService(Project project)
        {
            var service = new ProjectService();
            return service.RegisterProject(project);
        }

        private void ShowSuccessMessage(string message)
        {
            pnlMensagem.Visible = true;
            pnlMensagem.CssClass = "message message-success";
            lblMensagem.Text = message;
        }

        private void ShowErrorMessage(string message)
        {
            pnlMensagem.Visible = true;
            pnlMensagem.CssClass = "message message-error";
            lblMensagem.Text = message;
        }

        private void ClearMessage()
        {
            pnlMensagem.Visible = false;
            lblMensagem.Text = string.Empty;
        }

        private void ClearFields()
        {
            txtNumeroProjeto.Text = string.Empty;
            txtNumeroSubprojeto.Text = string.Empty;
            txtNomeProjeto.Text = string.Empty;
            txtNomeCoordenador.Text = string.Empty;
            txtSaldo.Text = string.Empty;
        }
    }
}
