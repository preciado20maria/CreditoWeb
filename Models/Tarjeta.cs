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
            int total=0;
            int suma=0;
            int impar=0;
            int par=0;
            
            for(int i=TarjetaNum.Length-1;i>=0;i-=2){
                par=0;
                int digito=(int)Char.GetNumericValue(TarjetaNum[i]);
                suma=suma+digito;
                if(i-1>=0){
                 par=(int)Char.GetNumericValue(TarjetaNum[i-1]);}
                var suma1=par*2;
                if(suma1>9){suma1=suma1-9;}
                impar=impar+suma1;

            }
        total=impar+suma;
            return total%10==0;
        }


        /// Si la tarjeta es valida determinar de cuál tipo es VISA, MASTERCARD, AMERICANEXPRESS
        /// como estamos dentro de la clase de tarjeta tenemos acceso a la propiedad TarjetaNum 
        private TipoTarjeta tipoDeTarjeta(

        )
        {
            var tipo=TipoTarjeta.NOVALIDA;
        if((TarjetaNum[0]=='3'&& TarjetaNum[1]=='4')||(TarjetaNum[0]=='3'&& TarjetaNum[1]=='7'))
        {
            tipo=TipoTarjeta.AMERICANEXPRESS;
        }
        if((TarjetaNum[0]=='5'&& TarjetaNum[1]=='1')||(TarjetaNum[0]=='5'&& TarjetaNum[1]=='2')||(TarjetaNum[0]=='5'&& TarjetaNum[1]=='3')||(TarjetaNum[0]=='5'&& TarjetaNum[1]=='4')||(TarjetaNum[0]=='5'&& TarjetaNum[1]=='5'))
        {
            tipo=TipoTarjeta.MASTERCARD;
        }    
         if(TarjetaNum[0]=='4')   
         {
             tipo=TipoTarjeta.VISA;
         }
 
            return tipo;
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