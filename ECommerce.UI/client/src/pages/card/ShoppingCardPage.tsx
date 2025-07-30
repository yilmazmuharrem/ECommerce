import { IconButton, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow } from "@mui/material";
import { Delete } from "@mui/icons-material";
import { useCartContext } from "../../context/CardContext";

export default function ShoppingCartPage() {
    const { cart } = useCartContext();

    // cart yoksa veya cart.cartItems boşsa
     if (!cart || !cart.cartItems || cart.cartItems.length === 0) {
         return <h1>Sepetinizde ürün yok</h1>;
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
                    {cart.cartItems.map((item) => (
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
                            <TableCell align="right">{item.price} ₺</TableCell>
                            <TableCell align="right">{item.quantity}</TableCell>
                            <TableCell align="right">{item.price * item.quantity} ₺</TableCell>
                            <TableCell align="right">
                                <IconButton color="error">
                                    <Delete />
                                </IconButton>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    );
}
