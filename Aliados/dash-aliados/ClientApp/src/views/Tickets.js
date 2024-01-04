import React, { useContext} from "react";
import BienvenidoPanel from "../components/BienvenidoPanel";
import Footer from "../components/Footer";
import DatosTickets from "../components/DatosTickets";
import TablaTickets from "../components/TablaTickets";
import ScrollToTopButton from "../components/ScrollToTopButton";
import TituloPagina from "../components/TituloPagina";
import { DatosInicioContext } from "../context/DatosInicioContext";

const Tickets = () => {
  const { datosCuponesContext } = useContext(DatosInicioContext);
  const { listaMes } = datosCuponesContext;
  return (
    <div>
      <div className="d-xl-block d-none mt-4 pt-4 ">
        <BienvenidoPanel />
      </div>
      <ScrollToTopButton />
      <div className="pt-2">
        <TituloPagina title="Cupones" />
      </div>
      <div className="my-3">
        <DatosTickets />
      </div>
      <TablaTickets listaMes={listaMes} />
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Tickets;
