import React from "react";
import BienvenidoPanel from "../../components/BienvenidoPanel";
import Footer from "../../components/Footer";
import FormComentarioCalificar from "../../components/FormComentarioCalificar";
import ScrollToTopButton from "../../components/ScrollToTopButton";
import TituloPagina from "../../components/TituloPagina";

const Calificar = () => {
  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Calificar" />
      </div>
      <div className="my-4">
        <FormComentarioCalificar />
      </div>
      <div style={{ paddingBottom: "4rem", paddingTop: "4rem" }}>
        <Footer />
      </div>
    </div>
  );
};

export default Calificar;
