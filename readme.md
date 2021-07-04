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