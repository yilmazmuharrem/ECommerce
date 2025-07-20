import { IProduct } from "../../model/IProduct";
import Product from "./Product";
import { Grid } from "@mui/material";

interface Props{
    products:IProduct[]
    
}


export default function ProductList({products}: Props) {
  return (
    <>
    <Grid container spacing={2}>
      {products.map((p) =>
      <Grid  key={p.id} size={{xs:12,md:4, lg:3}}>
         <Product key={p.id} product={p} /> 
        </Grid>
      )}
    </Grid>
    </>
  );
}