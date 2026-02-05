<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectsList.aspx.cs" Inherits="ProjectManagement.Web.ProjectsList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Consulta de Projetos</title>
    <link rel="stylesheet" href="Content/Site.css"/>
</head>
<body>
    <div class="container">
        <header>
            <h1>Sistema de Gestão de Projetos</h1>
            <nav>
                <a href="ProjectRegistration.aspx" class="active">Cadastrar Projeto</a>
                <a href="ProjectsList.aspx" class="active">Consultar Projetos</a>
            </nav>
        </header>

        <main>
            <form id="form1" runat="server">
                <div class="card">
                    <h2>Consulta de Projetos</h2>
                    
                    <asp:Panel ID="pnlMensagem" runat="server" Visible="false" CssClass="message">
                        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                    </asp:Panel>

                    <div class="search-section">
                        <div class="form-group">
                            <label>Tipo de Busca</label>
                            <asp:RadioButtonList ID="rblTipoBusca" runat="server" RepeatDirection="Horizontal" CssClass="radio-list">
                                <asp:ListItem Value="numero" Selected="True">Número do Projeto</asp:ListItem>
                                <asp:ListItem Value="nome">Nome do Projeto</asp:ListItem>
                                <asp:ListItem Value="todos">Todos os Projetos</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <div class="form-group">
                            <label for="txtBusca">Termo de Busca</label>
                            <asp:TextBox ID="txtBusca" runat="server" CssClass="form-control" 
                                         placeholder="Digite o termo para buscar..." MaxLength="200"></asp:TextBox>
                            <small class="form-text">Deixe em branco e selecione "Todos os Projetos" para listar todos</small>
                        </div>

                        <div class="form-actions">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                                        CssClass="btn btn-primary" OnClick="btnGet_Click" />
                            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" 
                                        CssClass="btn btn-secondary" OnClick="btnClear_Click" />
                        </div>
                    </div>
                </div>

                <asp:Panel ID="pnlResultados" runat="server" Visible="false" CssClass="card results-section">
                    <h3>Resultados da Consulta</h3>
                    <div class="table-container">
                        <asp:GridView ID="gvProjetos" runat="server" AutoGenerateColumns="False" 
                                      CssClass="table" EmptyDataText="Nenhum projeto encontrado.">
                            <Columns>
                                <asp:BoundField DataField="ProjectNumber" HeaderText="Nº Projeto" />
                                <asp:BoundField DataField="SubprojectNumber" HeaderText="Nº Subprojeto" />
                                <asp:BoundField DataField="ProjectName" HeaderText="Nome do Projeto" />
                                <asp:BoundField DataField="CoordinatorName" HeaderText="Coordenador" />
                                <asp:BoundField DataField="Balance" HeaderText="Saldo (R$)" DataFormatString="{0:N2}" />
                            </Columns>
                            <HeaderStyle CssClass="table-header" />
                            <RowStyle CssClass="table-row" />
                            <AlternatingRowStyle CssClass="table-row-alt" />
                        </asp:GridView>
                    </div>
                    <div class="result-count">
                        <asp:Label ID="lblContagem" runat="server" CssClass="count-label"></asp:Label>
                    </div>
                </asp:Panel>
            </form>
        </main>

        <footer>
            <p>&copy; 2025 - Sistema de Gestão de Projetos</p>
        </footer>
    </div>

    <div id="loader" class="loader-overlay" style="display: none;">
        <div class="loader-spinner"></div>
        <p>Buscando projetos...</p>
    </div>

    <script type="text/javascript">
        function showLoader() {
            document.getElementById('loader').style.display = 'flex';
        }

        function hideLoader() {
            document.getElementById('loader').style.display = 'none';
        }

        window.onload = function() {
            var btnBuscar = document.getElementById('<%= btnBuscar.ClientID %>');
            if (btnBuscar) {
                btnBuscar.onclick = function() {
                    showLoader();
                };
            }
        };
    </script>
</body>
</html>
