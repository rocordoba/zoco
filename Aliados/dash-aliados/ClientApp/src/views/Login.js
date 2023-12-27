import ContenidoLogin from "../components/ContenidoLogin";
import FooterLogin from "../components/FooterLogin";

const Login = ({ onSubmit, datosMandados, setDatosMandados }) => {
  return (
    <section className="bg-view-login ">
      <article className="">
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            height: "100vh",
          }}
        >
          <ContenidoLogin
            onSubmit={onSubmit}
            datosMandados={datosMandados}
            setDatosMandados={setDatosMandados}
          />
        </div>
      </article>
      <div className="d-flex justify-content-center">
        <FooterLogin />
      </div>
    </section>
  );
};

export default Login;
