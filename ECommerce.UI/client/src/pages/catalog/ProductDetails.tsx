import { CircularProgress, Divider, Grid, Stack, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router";
import { IProduct } from "../../model/IProduct";
import request from "../../api/request";
import NotFound from "../../errors/NotFound";
import { LoadingButton } from "@mui/lab";
import { AddShoppingCart } from "@mui/icons-material";
import { useCartContext } from "../../context/CardContext";
import { toast } from "react-toastify";
import { currencyTRY } from "../../utils/fortmatCurrency";

export default function ProductDetailsPage(){

    const {id }  = useParams<{id:string}>();
    const [product, setProduct] = useState<IProduct | null>(null)
    const [isAdded, setIsAdded] = useState(false)
    const [loading, setLoading] = useState(true)
    const {cart,setCart} = useCartContext()
    const item = cart?.cartItems.find(i=>i.productId == product?.id)
    useEffect(()=>{
    id && request.Catalog.details(parseInt(id))
    .then(data=>setProduct(data)).
    catch(error=>console.log(error))
    .finally(()=>setLoading(false));



    },[id])

    function handleAddItem(id:number){
        setIsAdded(true)
        request.Card.addItem(id,1)
        
        .then(cart=>{setCart(cart)
            toast.success("Sepetinize Ürün başarılı şekilde eklendi.")
        })
        .catch(error=>console.log(error)).finally(()=>setIsAdded(false))
    }
    if(loading) return <CircularProgress></CircularProgress>

    if (!product) {
        return <NotFound></NotFound>
    }
    return(
     <Grid container spacing={6}>
<Grid size={{xl:3,lg:4, md:5,sm:6,xs:12}}> 
    
    {/* <img src={product.imageUrl} alt=""  style={{width:"100%"}}/>  */}
    <img src={`http://localhost:7139/images/${product.id}.jpg`} alt=""  style={{width:"100%"}}/> 

</Grid>
<Grid size={{xl:9,lg:8,md:7, sm:6,xs:12}}>  


<Typography variant="h3"> {product.name}</Typography>
<Divider sx={{mb:2}} ></Divider>
<Typography variant="h4" color="secondary"> {currencyTRY.format (product.price)} ₺</Typography>
<TableContainer>
    <Table>
        <TableBody>
            <TableRow>
                <TableCell>  Name   </TableCell>
                <TableCell>  {product.name}   </TableCell>
            </TableRow>

             <TableRow>
                <TableCell>  Description   </TableCell>
                <TableCell>  {product.description}   </TableCell>
            </TableRow>

             <TableRow>
                <TableCell>  Stock   </TableCell>
                <TableCell>  {product.stock}   </TableCell>
            </TableRow>
        </TableBody>


    </Table>
</TableContainer>
<Stack direction="row" spacing={2} sx={{mt:3}} alignItems="center">
<LoadingButton
 variant="outlined" 
 loadingPosition="start"
 startIcon={<AddShoppingCart></AddShoppingCart>}
 loading={isAdded}
 onClick={()=>handleAddItem(product.id)}
 >
Sepete Ekle



</LoadingButton>
{
    item?.quantity!>0 && (
        <Typography variant="body2" >Sepetinize {item?.quantity} adet eklendi.</Typography>
    )
}
</Stack>
</Grid>


     </Grid>

    )
}