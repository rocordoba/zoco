import React from "react";
import "./ContenidoHome.css";
import HeroVideo from "./HeroVideo";



import Promesa from "./Promesa";
import PorqueZoco from "./PorqueZoco";
import Hardware from "./Hardware";
import SinCostosOcultos from "./SinCostosOcultos";
import MediosPago from "./MediosPago";
import PregFrecuentes from "./PregFrecuentes";
import FooterLanding from "./FooterLanding";
import NuevoNavReact from "../NuevoNavReact";

import { Navbar, Container, Nav, Button } from "react-bootstrap";
import { NavLink, Link, useNavigate } from "react-router-dom";


const ContenidoHome = () => {
  return (
    <div >
      <HeroVideo />
      <div className="contenido">
        <Promesa />
        <PorqueZoco />
        <Hardware />
        <SinCostosOcultos />
        <MediosPago />
        <PregFrecuentes />
        <FooterLanding />
      </div>
    </div>
  );
};

export default ContenidoHome;
