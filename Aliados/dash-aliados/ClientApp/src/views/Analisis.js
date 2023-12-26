import React from "react";
import BienvenidoPanel from "../components/BienvenidoPanel";
import Footer from "../components/Footer";
import DatosAnalisis from "../components/DatosAnalisis";
import EvolucionMensual3Barras from "../components/EvolucionMensual3Barras";
import TripleGraficoAnalisis from "../components/TripleGraficoAnalisis";
import ScrollToTopButton from "../components/ScrollToTopButton";
import TituloPagina from "../components/TituloPagina";


const Analisis = () => {
  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Análisis" />
      </div>
      <div className="my-3">
        <DatosAnalisis />
      </div>
      <EvolucionMensual3Barras />
      <TripleGraficoAnalisis />
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Analisis;
