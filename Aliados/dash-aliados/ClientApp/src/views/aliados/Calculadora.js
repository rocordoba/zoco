import React from "react";
import BienvenidoPanel from "../../components/BienvenidoPanel";
import Footer from "../../components/Footer";
import TablaCalculadora from "../../components/TablaCalculadora";
import ScrollToTopButton from "../../components/ScrollToTopButton";
import TituloPagina from "../../components/TituloPagina";

const Calculadora = () => {
  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Calculadora" />
      </div>
      <div>
        <TablaCalculadora />
      </div>
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Calculadora;
