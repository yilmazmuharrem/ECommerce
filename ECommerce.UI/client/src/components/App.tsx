
import { useEffect, useState } from "react";
import Header from "./Header";
import { CircularProgress, Container, CssBaseline } from "@mui/material";
import { Outlet } from "react-router";
import { ToastContainer } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';
import request from "../api/request";
import { useCartContext } from "../context/CardContext";

function App() {

  const { setCart} = useCartContext()
  const [ loading,setLoading] = useState(true)
useEffect(()=>{
request.Card.get()
.then(cart=>setCart(cart))
.catch( error=> console.log(error))
.finally(()=>setLoading(false))
},[])

if (loading) {
  return <CircularProgress></CircularProgress>
} 


  return (
    <>
    <ToastContainer position="bottom-right" hideProgressBar theme="colored" ></ToastContainer>
    <CssBaseline></CssBaseline>
      <Header  />
      <Container>
        
         
      <Outlet></Outlet>
      
      </Container>
      
    </>
  );
}

export default App;
