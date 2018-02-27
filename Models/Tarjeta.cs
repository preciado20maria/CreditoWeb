using System;
using System.ComponentModel.DataAnnotations;

namespace CreditoWeb.Models
{
    public class Tarjeta
    {
        [Required(ErrorMessage = "El número de tarjeta es necesario.")]
        //[CreditCard]
        public string TarjetaNum { get; set; }
        public TipoTarjeta TipoTarjeta { get; set; }

        public bool Valida { get; set; }
        public Tarjeta(string TarjetaNum)
        {
            this.TarjetaNum = TarjetaNum;
            TipoTarjeta = TipoTarjeta.NOVALIDA;
            Valida = false;
        }
        public Tarjeta()
        {
            
        }
    }

    public enum TipoTarjeta
    {
        VISA,
        MASTERCARD,
        AMERICANEXPRESS,
        NOVALIDA


    }
}