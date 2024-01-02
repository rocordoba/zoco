import { useContext } from "react";
import Buscador from "./Buscador";
import ItemsTablaTicket from "./ItemsTablaTicket";
import { DarkModeContext } from "../context/DarkModeContext";
import "./TablaTickets.css";

const datos = [
  {
    id: 1,
    fecha: "01-09-2023",
    bruto: 1000,
    costoFinal: 1000,
    costoAnt: 1000,
    arancel: 1000,
    ivaArancel: 1000,
    impDebCred: 1000,
    retenIIBB: 1000,
    retGanancia: 1000,
    retIva: 1000,
    total: 1000,
  },
  {
    id: 2,
    fecha: "02-09-2023",
    bruto: 2000,
    costoFinal: 2000,
    costoAnt: 2000,
    arancel: 2000,
    ivaArancel: 2000,
    impDebCred: 2000,
    retenIIBB: 2000,
    retGanancia: 2000,
    retIva: 2000,
    total: 2000,
  },
  {
    id: 3,
    fecha: "03-09-2023",
    bruto: 3000,
    costoFinal: 3000,
    costoAnt: 3000,
    arancel: 3000,
    ivaArancel: 3000,
    impDebCred: 3000,
    retenIIBB: 3000,
    retGanancia: 3000,
    retIva: 3000,
    total: 3000,
  },
  {
    id: 4,
    fecha: "04-09-2023",
    bruto: 4000,
    costoFinal: 4000,
    costoAnt: 4000,
    arancel: 4000,
    ivaArancel: 4000,
    impDebCred: 4000,
    retenIIBB: 4000,
    retGanancia: 4000,
    retIva: 4000,
    total: 4000,
  },
  {
    id: 5,
    fecha: "05-09-2023",
    bruto: 5000,
    costoFinal: 5000,
    costoAnt: 5000,
    arancel: 5000,
    ivaArancel: 5000,
    impDebCred: 5000,
    retenIIBB: 5000,
    retGanancia: 5000,
    retIva: 5000,
    total: 5000,
  },
  {
    id: 6,
    fecha: "06-09-2023",
    bruto: 6000,
    costoFinal: 6000,
    costoAnt: 6000,
    arancel: 6000,
    ivaArancel: 6000,
    impDebCred: 6000,
    retenIIBB: 6000,
    retGanancia: 6000,
    retIva: 6000,
    total: 6000,
  },
  {
    id: 7,
    fecha: "07-09-2023",
    bruto: 7000,
    costoFinal: 7000,
    costoAnt: 7000,
    arancel: 7000,
    ivaArancel: 7000,
    impDebCred: 7000,
    retenIIBB: 7000,
    retGanancia: 7000,
    retIva: 7000,
    total: 7000,
  },
  {
    id: 8,
    fecha: "08-09-2023",
    bruto: 8000,
    costoFinal: 8000,
    costoAnt: 8000,
    arancel: 8000,
    ivaArancel: 8000,
    impDebCred: 8000,
    retenIIBB: 8000,
    retGanancia: 8000,
    retIva: 8000,
    total: 8000,
  },
  {
    id: 9,
    fecha: "09-09-2023",
    bruto: 9000,
    costoFinal: 9000,
    costoAnt: 9000,
    arancel: 9000,
    ivaArancel: 9000,
    impDebCred: 9000,
    retenIIBB: 9000,
    retGanancia: 9000,
    retIva: 9000,
    total: 9000,
  },
];

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
              <th
              className={darkMode ? ' bg-white text-dark border-0 lato-regular fs-12 py-3 ' : 'bg-dark text-white fs-12 lato-regular py-3  '} 
                scope="col"
              >
                Ret. IVA <br /> (3%)
              </th>
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
