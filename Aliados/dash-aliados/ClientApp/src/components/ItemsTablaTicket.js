import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import { useEffect } from "react";

const ItemsTablaTicket = ({
  fecha,
  costoFinancieroEn,
  totalBruto,
  arancel,
  iva21,
  retencionIva,
  impuestoDebitoCredito,
  retencionProvincial,
  retencionGanacia,
}) => {
  const formatearFecha = (fecha) => {
    const fechaObj = new Date(fecha);
    const año = fechaObj.getFullYear();
    const mes = String(fechaObj.getMonth() + 1).padStart(2, "0");
    const dia = String(fechaObj.getDate()).padStart(2, "0");

    return `${año}-${mes}-${dia}`;
  };
  const { darkMode } = useContext(DarkModeContext);

  const formatearAPeso = (valor) => {
    const valorFormateado = new Intl.NumberFormat("es-AR", {
      style: "currency",
      currency: "ARS",
    }).format(valor);

    // Agregar comas como separadores de miles
    const partes = valorFormateado.split(",");
    partes[0] = partes[0]
      .replace(/\D/g, "")
      .replace(/\B(?=(\d{3})+(?!\d))/g, ".");
    return partes.join(",");
  };

  useEffect(() => {
    formatearFecha(fecha);
  }, []);

  function formatearValores(...valores) {
    return valores.map(valor => formatearAPeso(valor));
  }
  

  const valoresFormateados = formatearValores(totalBruto, costoFinancieroEn,arancel)
  

  const fechaFormateada = formatearFecha(fecha);


  return (
    <tr
      className={
        darkMode
          ? " tabla-borde-bottom  text-white"
          : "tabla-borde-bottom  text-dark"
      }
    >
      <td className="fs-13 lato-regular py-3 "> {fechaFormateada}</td>
      <td className="fs-13 lato-regular py-3 ">$ {valoresFormateados[0]}</td>
      <td className="fs-13 lato-regular py-3 ">$ {valoresFormateados[1]} </td>
      <td className="fs-13 lato-regular py-3 ">$ {valoresFormateados[2]}</td>
      <td className="fs-13 lato-regular py-3 ">$ {iva21}</td>
      <td className="fs-13 lato-regular py-3 ">$ {impuestoDebitoCredito} </td>
      <td className="fs-13 lato-regular py-3 ">$ {retencionProvincial} </td>
      <td className="fs-13 lato-regular py-3 ">$ {retencionGanacia}</td>
      <td className="fs-13 lato-regular py-3 ">$ {retencionIva}</td>
      <td className="fs-13 lato-regular py-3 ">$ </td>
      <td className="fs-13 lato-regular py-3 ">$ </td>
    </tr>
  );
};

export default ItemsTablaTicket;
