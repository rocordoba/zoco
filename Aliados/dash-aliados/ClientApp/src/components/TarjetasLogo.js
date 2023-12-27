// import amex from "../assets/img/amex.png";
// import argencard from "../assets/img/argencard.png";
// import cabal from "../assets/img/cabal.png";
// import diners from "../assets/img/diners.png";
// import master from "../assets/img/mastercard.png";
// import naranjax from "../assets/img/naranjax.png";
// import visa from "../assets/img/visa.png";


// const TarjetasLogo = ({tarjetasOrdenadas}) => {
//   console.log("🚀 ~ file: TarjetasLogo.js:11 ~ TarjetasLogo ~ tarjetasOrdenadas:", tarjetasOrdenadas)
//   return (
//     <div className="">
//       <div className="d-flex justify-content-around">
//         <article className="">
//           <img className="img-tarjeta " src={visa} alt="Visa credito" />
//         </article>
   
//         <article className="">
//           <img className="img-tarjeta " src={master} alt="Master Credito" />
//         </article>
//         <article className="">
//           <img className="img-tarjeta " src={argencard} alt="Master Debito" />
//         </article>
//         <article className="">
//           <img className="img-tarjeta " src={amex} alt="American Express" />
//         </article>
//         <article className="">
//           <img className="img-tarjeta " src={diners} alt="Diners" />
//         </article>
//         <article className="">
//           <img className="img-tarjeta " src={cabal} alt="Cabal Credito" />
//         </article>
//         <article className="">
//           <img className="img-tarjeta " src={naranjax} alt="Cabal Debito" />
//         </article>
     
       
//       </div>
//     </div>
//   );
// };

// export default TarjetasLogo;

import amexImg from "../assets/img/amex.png";
import argencardImg from "../assets/img/argencard.png";
import cabalImg from "../assets/img/cabal.png";
import dinersImg from "../assets/img/diners.png";
import masterImg from "../assets/img/mastercard.png";
import naranjaxImg from "../assets/img/naranjax.png";
import visaImg from "../assets/img/visa.png";

const TarjetasLogo = ({ tarjetasOrdenadas }) => {
  const imagenes = {
    Visa: visaImg,
    MasterCard: masterImg,
    Argencard: argencardImg,
    Amex: amexImg,
    Diners: dinersImg,
    Cabal: cabalImg,
    Naranjax: naranjaxImg,
  };

  return (
    <div className="">
    <div className="d-flex justify-content-around">
      {tarjetasOrdenadas.map((tarjeta, index) => (
        <article key={index} className="">
          <img className="img-tarjeta" src={imagenes[tarjeta]} alt={tarjeta} />
        </article>
      ))}
    </div>
  </div>
  );
};

export default TarjetasLogo;