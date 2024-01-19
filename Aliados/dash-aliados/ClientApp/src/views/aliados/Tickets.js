import React, { useContext, useEffect } from "react";
import BienvenidoPanel from "../../components/BienvenidoPanel";
import Footer from "../../components/Footer";
import DatosTickets from "../../components/DatosTickets";
import TablaTickets from "../../components/TablaTickets";
import ScrollToTopButton from "../../components/ScrollToTopButton";
import TituloPagina from "../../components/TituloPagina";
import { DatosInicioContext } from "../../context/DatosInicioContext";
import { useNavigate } from "react-router-dom";
const Tickets = () => {
    const { datosCuponesContext, codigoRespuesta, datos } = useContext(DatosInicioContext);
  const { listaMes } = datosCuponesContext;
    const history = useNavigate();
    const navegacion = useNavigate();
    function recargarPagina() {
        window.location.reload();

    }

    useEffect(() => {
        const verificarToken = async () => {
            const token = sessionStorage.getItem("token");

            try {
                const response = await fetch('/api/token/token', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                    body: JSON.stringify({ Token: token })
                });

                if (response.ok) {
                  
                } else {
                    if (response.status === 401 || token === null) {
                        navegacion("/");
                        recargarPagina();
                    } else {
                        throw new Error("Respuesta no satisfactoria del servidor");
                    }
                }
            } catch (error) {
                console.error("Error al validar el token", error);
            }
        };

        const checkResponseCodeAndRedirect = () => {
            if (codigoRespuesta !== null && codigoRespuesta !== 200) {
                console.log(codigoRespuesta);
                navegacion("/");
                recargarPagina();
            }
        };

        verificarToken();
        checkResponseCodeAndRedirect();
    }, [history, codigoRespuesta]);
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
        <DatosTickets  datosCuponesContext={datosCuponesContext}/>
      </div>
          <TablaTickets listaMes={listaMes} datos={datos} />
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Tickets;
