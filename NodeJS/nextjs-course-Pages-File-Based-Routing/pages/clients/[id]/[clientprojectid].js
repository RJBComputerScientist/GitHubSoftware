import { useRouter } from 'next/router';

function SelectedClientProjectPage(params) {
    const router = useRouter();

    console.log(router.pathname); // the pathname string
    console.log(router.query); //the value of the query
    
    return (
        <div>
            <h1>The Project Page For A Specific Project For A Specific Client</h1>
        </div>
    )
}

export default SelectedClientProjectPage;