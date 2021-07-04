# Run
```bash
dotnet watch run -p .\NetGraphqlExample.UserService\
dotnet watch run -p .\NetGraphqlExample.BlogService\
```

# Examples

```graphql
{
  posts {
    title
    author {
      id,
      address{
        city
      }
    }
  }
}
  ```

```graphql
{
  p1: post(id: 1) {
    title
    text
    comments {
      idPost
      text
    }
  }

  p2: post(id: 2) {
    title
    text
    comments {
      idPost
      text
    }
  }
}
```

```graphql
{
  p1: post(id: 1) {
    ...postFields
  }

  p2: post(id: 2) {
    ...postFields
  }
}

fragment postFields on Post {
  title
  text
  comments {
    idPost
    text
  }
}
```


```graphql
{
  posts {
    title
    text
    comments {
      idPost
      text
    }
  }
}
```

```graphql
query getPost($id: Int!) {
  p1: post(id: $id) {
    title
    text
    comments {
      idPost
      text
    }
  }
}

variables:
{
  "id":3
}
```


```graphql
mutation{
  addComment(idPost:1, text:"my new comment"){
    id
  }
}
```
