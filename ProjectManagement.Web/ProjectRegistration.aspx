<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectRegistration.aspx.cs" Inherits="ProjectManagement.Web.ProjectRegistration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Cadastro de Projeto</title>
    <link rel="stylesheet" href="Content/Site.css"/>
</head>
<body>
    <div class="container">
        <header>
            <h1>Sistema de Gestão de Projetos</h1>
            <nav>
                <a href="ProjectRegistration.aspx" class="active">Cadastrar Projeto</a>
                <a href="ProjectList.aspx">Consultar Projetos</a>
            </nav>
        </header>

        <main>
            <form id="form1" runat="server">
                <div class="card">
                    <h2>Cadastro de Projeto</h2>
                    
                    <asp:Panel ID="pnlMensagem" runat="server" Visible="false" CssClass="message">
                        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                    </asp:Panel>

                    <div class="form-group">
                        <label for="txtNumeroProjeto">Número do Projeto *</label>
                        <asp:TextBox ID="txtNumeroProjeto" runat="server" CssClass="form-control" 
                                     placeholder="Ex: 2024001" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txtNumeroSubprojeto">Número do Subprojeto *</label>
                        <asp:TextBox ID="txtNumeroSubprojeto" runat="server" CssClass="form-control" 
                                     placeholder="Ex: 001" MaxLength="50"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txtNomeProjeto">Nome do Projeto *</label>
                        <asp:TextBox ID="txtNomeProjeto" runat="server" CssClass="form-control" 
                                     placeholder="Ex: Pesquisa em Inteligência Artificial" MaxLength="200"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txtNomeCoordenador">Nome do Coordenador *</label>
                        <asp:TextBox ID="txtNomeCoordenador" runat="server" CssClass="form-control" 
                                     placeholder="Ex: Dr. João Silva" MaxLength="150"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txtSaldo">Saldo do Projeto (R$) *</label>
                        <asp:TextBox ID="txtSaldo" runat="server" CssClass="form-control" 
                                     placeholder="Ex: 150000.00" MaxLength="20"></asp:TextBox>
                    </div>

                    <div class="form-actions">
                        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar Projeto" 
                                    CssClass="btn btn-primary" OnClick="btnRegister_Click" />
                        <asp:Button ID="btnLimpar" runat="server" Text="Limpar Campos" 
                                    CssClass="btn btn-secondary" OnClick="btnClear_Click" />
                    </div>
                </div>
            </form>
        </main>

        <footer>
            <p>&copy; 2025 - Sistema de Gestão de Projetos</p>
        </footer>
    </div>

    <div id="loader" class="loader-overlay" style="display: none;">
        <div class="loader-spinner"></div>
        <p>Processando...</p>
    </div>

    <script type="text/javascript">
        function showLoader() {
            document.getElementById('loader').style.display = 'flex';
        }

        function hideLoader() {
            document.getElementById('loader').style.display = 'none';
        }

        window.onload = function() {
            var btnCadastrar = document.getElementById('<%= btnCadastrar.ClientID %>');
            if (btnCadastrar) {
                btnCadastrar.onclick = function() {
                    showLoader();
                };
            }
        };
    </script>
</body>
</html>
