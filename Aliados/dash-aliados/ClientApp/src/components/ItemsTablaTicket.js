import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";
import formatearValores from "../helpers/formatearAPeso";
import formatearFecha from "../helpers/formatearFecha";

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
  totalConDescuentos,
}) => {
  const { darkMode } = useContext(DarkModeContext);

  const valoresFormateados = formatearValores(
    totalBruto,
    costoFinancieroEn,
    arancel,
    iva21,
    impuestoDebitoCredito,
    iva21,
    impuestoDebitoCredito,
    retencionProvincial,
    retencionGanacia,
    retencionIva,
    totalConDescuentos
  );

  const fechaFormateada = formatearFecha(fecha);

  return (
    <tr
      className={
        darkMode
          ? " tabla-borde-bottom  text-white"
          : "tabla-borde-bottom  text-dark"
      }
    >
      <td className="fs-12-a-10 lato-regular py-3 "> {fechaFormateada}</td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        $ {valoresFormateados[0]}
      </td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        $ {valoresFormateados[1]}{" "}
      </td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        $ {valoresFormateados[2]}
      </td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        $ {valoresFormateados[3]}
      </td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        $ {valoresFormateados[4]}{" "}
      </td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        $ {valoresFormateados[5]}{" "}
      </td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        $ {valoresFormateados[6]}
      </td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        $ {valoresFormateados[7]}
      </td>
      <td className="fs-12-a-10 lato-regular py-3 ">
        ${valoresFormateados[10]}{" "}
      </td>
    </tr>
  );
};

export default ItemsTablaTicket;
