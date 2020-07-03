using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ByteBank.Agencias.DAL;

namespace ByteBank.Agencias
{
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;

        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));

            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {
            //var okEventHandler = (RoutedEventHandler)btnOk_Click + Fechar;
            //var cancelarEventHandler =
            //    (RoutedEventHandler)Delegate.Combine(
            //        (RoutedEventHandler)btnCancelar_Click,
            //        (RoutedEventHandler)Fechar);

            //RoutedEventHandler dialogResultTrue = delegate (object o, RoutedEventArgs e)
            //{
            //    DialogResult = true;
            //};

            //RoutedEventHandler dialogResultFalse = delegate (object o, RoutedEventArgs e)
            //{
            //    DialogResult = true;
            //};

            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            txtNome.TextChanged += ValidacaoCampoNulo;
            txtDescricao.TextChanged += ValidacaoCampoNulo;
            txtEndereco.TextChanged += ValidacaoCampoNulo;
            txtNumero.TextChanged += ValidacaoCampoNulo;
            txtTelefone.TextChanged += ValidacaoCampoNulo;
        }

        private void ValidacaoCampoNulo(object o, EventArgs e)
        {
            var txt = o as TextBox;
            var textoEstaVazio = string.IsNullOrEmpty(txt.Text);

            txt.Background = textoEstaVazio
                ? new SolidColorBrush(Colors.OrangeRed)
                : new SolidColorBrush(Colors.White);
        }

        private void Fechar(object sender, EventArgs e) => Close();
    }
}
