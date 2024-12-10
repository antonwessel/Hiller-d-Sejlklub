using ClassLibrary.Core.Models;

namespace ClassLibrary.MockData;

public class MockBlog
{
    private static Dictionary<string, Blog> _blogs = new()
    {
        {
            "Sommersejlads på Esrum Sø",
            new Blog(
                "Sommersejlads på Esrum Sø",
                "Henrik Sørensen",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                new DateTime(2025, 7, 10, 14, 30, 0) // 10. juli 2025, kl. 14:30
            )
        },
        {
            "Efterårstur til Nødebo Jollehavn",
            new Blog(
                "Efterårstur til Nødebo Jollehavn",
                "Henrik Sørensen",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor. Maecenas faucibus mollis interdum. Integer posuere erat a ante venenatis dapibus posuere velit aliquet. Aenean eu leo quam. Pellentesque ornare sem lacinia quam venenatis vestibulum. Nullam id dolor id nibh ultricies vehicula ut id elit. Donec sed odio dui. Cras justo odio, dapibus ac facilisis in, egestas eget quam.",
                new DateTime(2025, 9, 15, 10, 0, 0) // 15. september 2025, kl. 10:00
            )
        }
    };

    public static List<Blog> GetBlogsAsList() => _blogs.Values.ToList();
}
