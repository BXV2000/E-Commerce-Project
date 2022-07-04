

//export const SideBar = () => {
//    const [isOpen, setIsOpen] = useState(false);
//    function setIsOpen() {
//        ...
//    }
//    return (
//        <>
//            <IconButton size='large' edge='start' color='black' aria-label='logo' onClick{() => setIsOpen(true)}>
//                <MenuIcon />
//            </IconButton>
//        <Drawer anchor='left' open={isOpen} onClose={() => setIsOpen(false)}>
//            <Box p={2} width='250px' textAlign='center' role='presentation'>
//                <Typography variant='h6' component='div'>
//                    Side Panel
//                </Typography>
//            </Box>
//            </Drawer>
//        </>
//    )
//}

export class SideBar extends Comment {
    constructor(props) {
        super(props);
        this.state = {
            isOpen: false,
        };
    }

    setOpen = () => {
        this.setState({ isOpen: true })
    }

    render() {
        return (
            <>
                Bar
            </>
            )
    }
}