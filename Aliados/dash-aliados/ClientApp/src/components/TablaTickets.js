import { useContext } from "react";
import Buscador from "./Buscador";
import ItemsTablaTicket from "./ItemsTablaTicket";
import { DarkModeContext } from "../context/DarkModeContext";
import "./TablaTickets.css";

const TablaTickets = ({listaMes}) => {
  const { darkMode } = useContext(DarkModeContext);
  const listaDelMes = listaMes || [];
  console.log("🚀 ~ file: TablaTickets.js:139 ~ TablaTickets ~ listaDelMes:", listaDelMes)

  return (
    <section>
      <Buscador />
      <div
        className={
          darkMode
            ? " container table-responsive py-5 px-5 bg-tabla-calculadora-dark my-5"
            : "container table-responsive py-5 px-5 bg-tabla-calculadora my-5"
        }
      >
        <table className="table table-borderless responsive striped hover">
          <thead className="border-0 ">
            <tr className="text-center tabla-thead">
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-tabla-izquierda border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white border-tabla-izquierda border-0 lato-regular fs-12 py-3 "
                }
                scope="col "
              >
                Fecha <br /> de pago
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3  "
                }
                scope="col"
              >
                Bruto
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3  "
                }
                scope="col"
              >
                Costo <br /> Fin.
              </th>
              <th
                className={
                  darkMode
                    ? " bg-white text-dark border-0 lato-regular fs-12 py-3 "
                    : "bg-dark text-white fs-12 lato-regular py-3 "
                }
                scope="col"
              >
                Arancel
              </th>
              <th
              className={darkMode ? ' bg-white text-dark border-0 lato-regular fs-12 py-3 ' : 'bg-dark text-white fs-12 lato-regular py-3  '} 
                scope="col"
              >
                IVA <br /> Arancel
              </th>
              <th
              className={darkMode ? ' bg-white text-dark border-0 lato-regular fs-12 py-3' : 'bg-dark text-white fs-12 lato-regular py-3 '} 
                scope="col"
              >
                Imp. <br /> Deb/Cred
              </th>
              <th
              className={darkMode ? ' bg-white text-dark border-0 lato-regular fs-12 py-3 ' : 'bg-dark text-white fs-12 lato-regular py-3 '} 
                scope="col"
              >
                Reten. <br /> IIBB
              </th>
              <th
              className={darkMode ? ' bg-white text-dark border-0 lato-regular fs-12 py-3 ' : 'bg-dark text-white fs-12 lato-regular py-3 '} 
                scope="col"
              >
                Ret. <br /> Ganancía
              </th>
              <th
              className={darkMode ? ' bg-white text-dark border-0 lato-regular fs-12 py-3 ' : 'bg-dark text-white fs-12 lato-regular py-3 '} 
                scope="col"
              >
                Ret. <br /> IVA
              </th>
              {/* <th
              className={darkMode ? ' bg-white text-dark border-0 lato-regular fs-12 py-3 ' : 'bg-dark text-white fs-12 lato-regular py-3  '} 
                scope="col"
              >
                Ret. IVA <br /> (3%)
              </th> */}
              <th
                className="bg-verde text-white border-tabla-derecha lato-regular py-3  "
                scope="col"
              >
                TOTAL
              </th>
            </tr>
          </thead>
          <tbody className="text-center">
            {listaDelMes.map((dato, id) => (
              <ItemsTablaTicket {...dato} key={id}></ItemsTablaTicket>
            ))}
          </tbody>
        </table>
      </div>
    </section>
  );
};

export default TablaTickets;
