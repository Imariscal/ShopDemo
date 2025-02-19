export const  validationMessages: any = {
    code: { required: 'Code is required.', minLength: 'Code must be at least 3 characters.' },
    description: { required: 'Description is required.' },
    prize: { required: 'Price is required.', min: 'Price must be greater than 0.' },
    image: { required: 'Image URL is required.' },
    stock: { required: 'Stock is required.', min: 'Stock must be at least 1.' }
  };


  export const shopValidationMessages : any = {
    name: { required: 'Shop name is required.', minLength: 'Name must be at least 3 characters.' },
    address: { required: 'Address is required.' }
  };
 

  
  export const clientValidationMessages : any = {
    name: { required: 'Client name is required.', minLength: 'Name must be at least 3 characters.' },
    address: { required: 'Address is required.' },
    lastName :{ required: 'Last Name is required.' },
  };
 