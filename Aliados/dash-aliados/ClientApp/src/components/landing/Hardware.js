import React from "react";
import dimg from "../../assets/img/dimg5ab.png";

const Hardware = () => {
  return (
    <div className="hardware cuadro-degradado" id="hardware">
      <div className="hardware-texto">
        <div className="div-img-posnet">
          <img src={dimg} className="hardware-img" alt="hardware nuevo" />
        </div>
        <div className="texto-postnet">
          <h1 className="title">Hardware que te ayuda a vender a tu manera</h1>
          <p className="hardware-p">
            Acepta pagos, imprime recibos y administra tu negocio con una
            terminal de pagos eficaz y portátil.
          </p>
        </div>
      </div>
    </div>
  );
};

export default Hardware;
