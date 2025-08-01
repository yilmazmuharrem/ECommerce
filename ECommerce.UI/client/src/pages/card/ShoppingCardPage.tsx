import { Alert, Button,  Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import { Delete } from "@mui/icons-material";
import { useCartContext } from "../../context/CardContext";
import AddCircleIcon from '@mui/icons-material/AddCircle';
import RemoveCircleOutlineIcon from '@mui/icons-material/RemoveCircleOutline';
import { useState } from "react";
import request from "../../api/request";
import { toast } from "react-toastify";
import { currencyTRY } from "../../utils/fortmatCurrency";
import CardSummary from "./CardSummary";
export default function ShoppingCartPage() {
    const { cart,setCart } = useCartContext();
   const [status, setStatus] = useState({loading:false,id:""})

   function handleAddItem(productId:number,id:string){
      setStatus({loading:true,id:id})
      request.Card.addItem(productId,1).then(cart=>setCart(cart))
      .catch(error=>console.log(error)).finally(()=>      setStatus({loading:false,id:""})
)
   }
console.log(cart,"cart bilgileri")

   
   function handleDeleteItem(productId:number,id:string, quantity=1){
      setStatus({loading:true,id:id})
      console.log(quantity)
      request.Card.deleteItem(productId,quantity)
      .then((cart)=>setCart(cart))
      .catch(error=>console.log(error))
      .finally(()=>      setStatus({loading:false,id:id})
)
   }

    // cart yoksa veya cart.cartItems boşsa
     if ( cart?.cartItems.length === 0) {
         return <Alert severity="warning"> Sepetinizde Ürün Yok</Alert>
     }

    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }} aria-label="shopping cart table">
                <TableHead>
                    <TableRow>
                        <TableCell></TableCell>
                        <TableCell>Ürün</TableCell>
                        <TableCell align="right">Fiyat</TableCell>
                        <TableCell align="right">Adet</TableCell>
                        <TableCell align="right">Toplam</TableCell>
                        <TableCell align="right"></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {cart?.cartItems.map((item) => (
                        <TableRow
                            key={item.productId}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                            <TableCell>
                                <img
                                    src={`http://localhost:7139/images/${item.productId}.jpg`}
                                    style={{ height: 60 }}
                                    alt={item.name}
                                />
                            </TableCell>
                            <TableCell>{item.name}</TableCell>
                            <TableCell align="right">{ currencyTRY.format( item.price)} </TableCell>
                            <TableCell align="right">
                             <Button  loading={status.loading && status.id ==="add"+item.productId }  onClick={()=>handleAddItem(item.productId,"add"+item.productId)} >    <AddCircleIcon></AddCircleIcon>   </Button>
                            
                             
                              {item.quantity}
                              <Button loading={status.loading && status.id ==="del"+item.productId } 
                              onClick={()=>handleDeleteItem(item.productId,"del"+item.productId)} >  <RemoveCircleOutlineIcon></RemoveCircleOutlineIcon> </Button>
                              
                              </TableCell>
                            <TableCell align="right">{currencyTRY.format(item.price * item.quantity)} ₺</TableCell>
                            <TableCell align="right">
                                <Button color="error"
                                
                                
                                loading={status.loading && status.id ==="del_all"+item.productId } 
                                onClick={()=>{handleDeleteItem(item.productId,"del_all"+item.productId,item.quantity)
                                    toast.error("Ürün sepetiniziden silindi")
                                }}>
                                    <Delete />
                                </Button>
                            </TableCell>
                        </TableRow>
                    ))}
                                <CardSummary />

                </TableBody>
            </Table>
        </TableContainer>
    );
}
