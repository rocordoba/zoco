import React, { useContext, useEffect, useState } from "react";
import BienvenidoPanel from "../../components/BienvenidoPanel";
import Footer from "../../components/Footer";
import DatosContabilidad from "../../components/DatosContabilidad";
import ImpuestosCards from "../../components/ImpuestosCards";
import ScrollToTopButton from "../../components/ScrollToTopButton";
import TituloPagina from "../../components/TituloPagina";
import { DatosInicioContext } from "../../context/DatosInicioContext";
import Impuesto2Cards from "../../components/Impuesto2Cards";
import Impuesto2CardsBn from "../../components/Impuesto2CardsBn";
import { useNavigate } from "react-router-dom";
const Contabilidad = () => {
    const { datosContabilidadContext, codigoRespuesta } = useContext(DatosInicioContext);

    const navegacion = useNavigate();
    const history = useNavigate();
    function recargarPagina() {
        window.location.reload();
     
    }
    const [contabilidad, setdatoscontabilidad] = useState([]);
   
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
                    obtenerTasaInteres();
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
        }; const obtenerTasaInteres = async () => {
            try {
                const response = await fetch('/api/tasainteres/tasainteres', {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                        // Aseg�rate de incluir cualquier encabezado de autenticaci�n si es necesario
                    }
                });

                if (response.ok) {
                    const data = await response.json();
                    setdatoscontabilidad(data);
                   
                    // Aqu� puedes manejar los datos recibidos como prefieras
                } else {
                    throw new Error("No se pudieron obtener los datos de TasaInteres");
                }
            } catch (error) {
                console.error("Error al obtener datos de TasaInteres", error);
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
        <TituloPagina title="Contabilidad" />
      </div>
      <div className="my-3">
        <DatosContabilidad datosBack={datosContabilidadContext} />
      </div>
      {/* <ImpuestosCards datosBack={datosContabilidadContext} /> */}
      <section className="d-lg-block d-none">
        <div className="py-5">
          <Impuesto2Cards datosBack={datosContabilidadContext} />
        </div>
        <div className="py-2">
                  <Impuesto2CardsBn DatosTasa={contabilidad} />
        </div>
      </section>
      <section className="d-block d-lg-none">
        <div className="py-5">
                  <ImpuestosCards datosBack={datosContabilidadContext} DatosTasa={contabilidad} />
        </div>
      </section>
      <div className="py-4">
        <Footer />
      </div>
    </div>
  );
};

export default Contabilidad;
