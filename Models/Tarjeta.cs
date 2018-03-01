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
     
        public Tarjeta(string tarjetaNum)
        {
            this.TarjetaNum = tarjetaNum;
            Valida = esValida();
            TipoTarjeta = tipoDeTarjeta();            
        }


        /// Basado en el algoritmo de Luhn determinar si esta tarjeta es valida
        /// como estamos dentro de la clase de tarjeta tenemos acceso a la propiedad TarjetaNum 
        private bool esValida()
        {
            return false;
        }


        /// Si la tarjeta es valida determinar de cuál tipo es VISA, MASTERCARD, AMERICANEXPRESS
        /// como estamos dentro de la clase de tarjeta tenemos acceso a la propiedad TarjetaNum 
        private TipoTarjeta tipoDeTarjeta()
        {
            return TipoTarjeta.NOVALIDA;
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