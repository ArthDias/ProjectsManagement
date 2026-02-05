using System;
using System.Collections.Generic;
using System.Web.UI;
using ProjectManagement.Models;
using ProjectManagement.WCF;

namespace ProjectManagement.Web
{
    public partial class ProjectsList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClearMessage();
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                string searchType = rblTipoBusca.SelectedValue;
                string searchTerm = txtBusca.Text.Trim();


                if ((searchType == "numero" || searchType == "nome") && string.IsNullOrWhiteSpace(searchTerm))
                {
                    ShowErrorMessage($"Por favor, informe um termo de busca para consultar por {(searchType == "numero" ? "número" : "nome")} do projeto.");
                    txtBusca.Focus();
                    return;
                }

                List<Project> projects = Search(searchType, searchTerm);

                ShowResults(projects);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Erro ao buscar projetos: {ex.Message}");
                pnlResultados.Visible = false;
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtBusca.Text = string.Empty;
            rblTipoBusca.SelectedIndex = 0;
            pnlResultados.Visible = false;
            ClearMessage();
        }

        private List<Project> Search(string searchType, string searchTerm)
        {
            var service = new ProjectService();

            switch (searchType)
            {
                case "numero":
                    return service.GetByProjectNumber(searchTerm);

                case "nome":
                    return service.GetByProjectName(searchTerm);

                case "todos":
                    return service.GetAllProjects();

                default:
                    return new List<Project>();
            }
        }

        private void ShowResults(List<Project> projects)
        {
            if (projects == null || projects.Count == 0)
            {
                ShowInfoMessage("Nenhum projeto foi encontrado com os critérios informados.");
                pnlResultados.Visible = false;
                return;
            }

            ClearMessage();

            gvProjetos.DataSource = projects;
            gvProjetos.DataBind();

            string countText = projects.Count == 1
                ? "1 projeto encontrado"
                : $"{projects.Count} projetos encontrados";
            lblContagem.Text = countText;

            pnlResultados.Visible = true;
        }

        private void ShowErrorMessage(string mensagem)
        {
            pnlMensagem.Visible = true;
            pnlMensagem.CssClass = "message message-error";
            lblMensagem.Text = mensagem;
        }

        private void ShowInfoMessage(string mensagem)
        {
            pnlMensagem.Visible = true;
            pnlMensagem.CssClass = "message message-info";
            lblMensagem.Text = mensagem;
        }

        private void ClearMessage()
        {
            pnlMensagem.Visible = false;
            lblMensagem.Text = string.Empty;
        }
    }
}
