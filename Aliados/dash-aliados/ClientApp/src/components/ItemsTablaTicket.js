import { useContext } from "react";
import { DarkModeContext } from "../context/DarkModeContext";

const ItemsTablaTicket = ({
    fecha,
    bruto,
    costoFinal,
    costoAnt,
    arancel,
    ivaArancel,
    impDebCred,
    retenIIBB,
    retGanancia,
    retIva,
    total }) => {
    const { darkMode } = useContext(DarkModeContext)
    return (
        <tr className={darkMode ? ' tabla-borde-bottom  text-white' : 'tabla-borde-bottom  text-dark'} >
            <td className="fs-13 lato-regular py-3 "> {fecha}</td>
            <td className="fs-13 lato-regular py-3 ">$ {bruto}</td>
            <td className="fs-13 lato-regular py-3 ">$ {costoFinal}</td>
            <td className="fs-13 lato-regular py-3 ">$ {costoAnt}</td>
            <td className="fs-13 lato-regular py-3 ">$ {arancel}</td>
            <td className="fs-13 lato-regular py-3 ">$ {ivaArancel}</td>
            <td className="fs-13 lato-regular py-3 ">$ {impDebCred}</td>
            <td className="fs-13 lato-regular py-3 ">$ {retenIIBB}</td>
            <td className="fs-13 lato-regular py-3 ">$ {retGanancia}</td>
            <td className="fs-13 lato-regular py-3 ">$ {retIva}</td>
            <td className="fs-13 lato-regular py-3 ">$ {total}</td>
        </tr>
    )

}

export default ItemsTablaTicket;