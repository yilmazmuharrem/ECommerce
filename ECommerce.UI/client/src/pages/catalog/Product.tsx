import { Button, Card, CardActions, CardContent, CardMedia, Typography } from "@mui/material";
import { IProduct } from "../../model/IProduct";
import SearchIcon from '@mui/icons-material/Search';
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import { Link } from "react-router";
interface Props{
    product:IProduct
}

export default function Product({product}: Props) {
  return (
   <>
   <Card>

<CardMedia sx={ {height:160, backgroundSize:"contain"}} image={`http://localhost:7139/images/${product.id}.jpg`} ></CardMedia>
<CardContent>
   <Typography gutterBottom variant="h6" component="h2" color="text-secondary" >{product.name}</Typography>
   <Typography variant="body2" color="secondary" >
      {(product.price / 10).toFixed(2)} ₺
   </Typography>
</CardContent>
<CardActions>
   <Button  variant="outlined" size="small" startIcon={<AddShoppingCartIcon></AddShoppingCartIcon>} color="success" > Add to Card</Button>
   <Button component={Link} to={`/catalog/${product.id}`} variant="outlined" size="small" startIcon={<SearchIcon></SearchIcon>} color="primary"> View</Button>
</CardActions>
   </Card>


   
   </>
  );
}