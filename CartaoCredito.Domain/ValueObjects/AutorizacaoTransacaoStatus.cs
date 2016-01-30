namespace CartaoCredito.Domain.ValueObjects
{
    /// <summary>
    /// Status da autorização cartão de crédito
    /// </summary>
    public enum AutorizacaoTransacaoStatus
    {  
        Erro = 0,      
        Autorizado = 1,
        NaoAutorizado = 2,
        TransacaoComErroDeProcessamento = 3,
        PendenteDeCaptura = 4        
    }    
}
