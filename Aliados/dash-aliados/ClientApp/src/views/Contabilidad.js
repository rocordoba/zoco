import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../components/BienvenidoPanel";
import Footer from "../components/Footer";
import DatosContabilidad from "../components/DatosContabilidad";
import ImpuestosCards from "../components/ImpuestosCards";
import ScrollToTopButton from "../components/ScrollToTopButton";
import TituloPagina from "../components/TituloPagina";
import { DatosInicioContext } from "../context/DatosInicioContext";
import Impuesto2Cards from "../components/Impuesto2Cards";
import Impuesto2CardsBn from "../components/Impuesto2CardsBn";

const Contabilidad = () => {
  const { datosContabilidadContext } = useContext(DatosInicioContext);

  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Contabilidad" />
      </div>
      <div className="my-3">
        <DatosContabilidad datosBack={datosContabilidadContext} />
      </div>
      {/* <ImpuestosCards datosBack={datosContabilidadContext} /> */}
      <section className="d-lg-block d-none">
        <div className="py-5">
          <Impuesto2Cards />
        </div>
        <div className="py-2">
          <Impuesto2CardsBn />
        </div>
      </section>
      <section className="d-block d-lg-none">
        <div className="py-5">
        <ImpuestosCards datosBack={datosContabilidadContext} /> 
        </div>
      </section>
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Contabilidad;
