using System;
using System.Collections.Generic;
using CartaoCredito.Domain.Entities;
using CartaoCredito.Domain.Services;
using CartaoCredito.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CartaoCredito.Domain.Test
{
    [TestClass]
    public class TestAutorizacaoTransacaoService
    {
        private AutorizacaoTransacaoService _transacaoService;        
        private AutorizacaoTransacaoPedido _transacaoPedido;

        [TestInitialize]
        public void IniciarTestes()
        {
            _transacaoService = new AutorizacaoTransacaoService();
            _transacaoPedido = new AutorizacaoTransacaoPedido
            {
                //Dados da transação
                Descricao = "Teste",
                NumeroDeParcelas = 1,
                Valor = 300.0,
                DataDaTransacao = DateTime.Now,
                //Dados do cartão de crédito
                CartaoDeCredito = new CartaoDeCredito()
                {
                    Numero = "85641754852221458",
                    Bandeira = Bandeira.Mastercard,
                    Nome = "Eduardo Souza",
                    CodigoDeSeguraca = "123",
                    AnoDeExpiracao = 2020,
                    MesDeExpiracao = 7
                },

                //Dados do comprador
                Comprador = new Comprador
                {
                    CompradorId = 1,
                    Nome = "Teste",
                    Email = "teste@teste.com.br",
                    Endereco = new Endereco
                    {
                        Logradouro = "Rua: Dom gerardo",
                        Numero = "720",
                        Complemento = "",
                        Bairro = "Centro",
                        Cep = "23045-160",
                        Municipio = "Rio de janeiro",
                        Estado = "RJ"
                    },
                },
                CarrinhoDeCompras = new CarrinhoDeCompras
                {
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            ItemId = 1,
                            Nome = "Livro",
                            Descricao = "Livro MVC4",
                            Valor = 150.0,
                            ValorTotal = 300.0,
                            Quantidade = 2
                        }
                    }
                },
            };


        }

        [TestMethod]
        public void Obter_Autorizacao_Cartao_De_Credito_Autorizado()
        {
            //Valor até 1000, resultado: Autorizado
            var retorno = _transacaoService.ObterAutorizacao(_transacaoPedido);
            Assert.AreEqual(retorno.TransacaoStatusAutorizacao, AutorizacaoTransacaoStatus.Autorizado);
        }

        [TestMethod]
        public void Obter_Autorizacao_Cartao_De_Credito_Nao_Autorizado()
        {
            //Valor de 1001 a 2000, resultado: não autorizado            
            _transacaoPedido.Valor = 1001;            
            var retorno = _transacaoService.ObterAutorizacao(_transacaoPedido);
            Assert.AreEqual(retorno.TransacaoStatusAutorizacao, AutorizacaoTransacaoStatus.NaoAutorizado);
        }

        [TestMethod]
        public void Obter_Autorizacao_Cartao_De_Credito_transacao_com_erro_de_processamento()
        {
            //Valor de 2001 a 3000, resultado: Transação com erro de processamento            
            _transacaoPedido.Valor = 2001;            
            var retorno = _transacaoService.ObterAutorizacao(_transacaoPedido);
            Assert.AreEqual(retorno.TransacaoStatusAutorizacao, AutorizacaoTransacaoStatus.TransacaoComErroDeProcessamento);
        }

        [TestMethod]
        public void Obter_Autorizacao_Cartao_De_Credito_Pendente_de_captura()
        {
            //Valor de 3001 a 4000, resultado: Transação com erro de processamento
            _transacaoPedido.Valor = 3001;
            var retorno = _transacaoService.ObterAutorizacao(_transacaoPedido);
            Assert.AreEqual(retorno.TransacaoStatusAutorizacao, AutorizacaoTransacaoStatus.PendenteDeCaptura);
        }
    }
}
