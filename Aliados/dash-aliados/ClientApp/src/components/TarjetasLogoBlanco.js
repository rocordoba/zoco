import amex from "../assets/img/amex-blanco.png";
import argencard from "../assets/img/argencard-blanco.png";
import cabal from "../assets/img/cabal-blanco.png";
import diners from "../assets/img/diners-blanco.png";
import master from "../assets/img/mastercard-blanco.png";
import naranjax from "../assets/img/naranjax-blanco.png";
import visa from "../assets/img/visa-blanco.png";


const TarjetasLogoBlanco = () => {
  return (
    <div className="">
      <div className="d-flex justify-content-around">
        <article className="">
          <img className="img-tarjeta " src={visa} alt="Visa credito" />
        </article>
   
        <article className="">
          <img className="img-tarjeta " src={master} alt="Master Credito" />
        </article>
        <article className="">
          <img className="img-tarjeta " src={argencard} alt="Master Debito" />
        </article>
        <article className="">
          <img className="img-tarjeta " src={amex} alt="American Express" />
        </article>
        <article className="">
          <img className="img-tarjeta " src={diners} alt="Diners" />
        </article>
        <article className="">
          <img className="img-tarjeta " src={cabal} alt="Cabal Credito" />
        </article>
        <article className="">
          <img className="img-tarjeta " src={naranjax} alt="Cabal Debito" />
        </article>
     
       
      </div>
    </div>
  );
};

export default TarjetasLogoBlanco;