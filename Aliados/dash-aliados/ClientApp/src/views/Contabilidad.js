import React  from "react";
import BienvenidoPanel from "../components/BienvenidoPanel";
import Footer from "../components/Footer";
import DatosContabilidad from "../components/DatosContabilidad";
import ImpuestosCards from "../components/ImpuestosCards";
import ScrollToTopButton from "../components/ScrollToTopButton";
import TituloPagina from "../components/TituloPagina";


const Contabilidad = () => {
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
        <DatosContabilidad />
      </div>
      <ImpuestosCards />
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Contabilidad;
