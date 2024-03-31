- Pre-rendering helps with avoid http loads to a server
- getStaticProps() prepares the props of my object
- getStaticProps() wont be expose to the client side
- getStaticProps() should always have a object with a "props" key
- getStaticProps() is executed on the server side with server side capabilities. So,
the fs module can be used inside of this nextJS method.
- process.cwd() looks at the main root of the project and not the folder I am in.
- REMEMBER Pre-Rendering & Data Fetching with getStaticProps() never reaches the client, its
only executed when NextJS pre-renders the page.
- using "revalidate" in getStaticProps() help regenerate the data from the server based on seconds given.
this works in global timing not in active user timing, so if its set on 10 seconds to re fetch and you
reload in 5 seconds, it will take another 5 seconds to add up to 10 seconds to than be revalidated.
- REMEMBER getStaticProps() runs before the component function runs
- getStaticPaths() is to tell nextJS which instances of this dynamic page should be generated
- getStaticPaths() should always have a object with a "paths" key
- fallback is useful when having alot of data in your server to load to the client-side
- getServerSideProps() will get data from the server, this is not pre-generated data like getStaticProps()

