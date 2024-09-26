namespace MauiChat.Services;

public static class ChatService
{
    public static IEnumerable<MessageItem> GetInitialMessages()
    {
        return
        [
            new() {
                Body = "Hello!",
                Created = DateTime.Now.AddDays(-10),
                IsMyMessage = false
            },
            new() {
                Body = "I'm an echo chat. Write something and I'll echo it back",
                Created = DateTime.Now.AddDays(-1),
                IsMyMessage = false
            }
        ];
    }

    public static MessageItem SendMessage(string messageBody, ObservableCollection<MediaItem> messageAttachments)
    {
        var message = new MessageItem
        {
            Body = messageBody,
            Created = DateTime.Now,
            IsMyMessage = true
        };

        if (messageAttachments.Any())
        {
            message.Attachments.AddRange(messageAttachments);
        }
        //i think it needs to actually store the message so that the other person can see it on their phone
        //validate message to see if it violates a boundary
        //get boundaryTopicList

       // if (messageBody.Contains(string[] boundaryTopicList)

        //if boundaryviolated = true, route response through chatgpt canned loopback chat response pattern

            //else if boundary violated = true, pass message on to recipeient

        return message;
    }

    public static bool ContainsBoundaryTopic(MessageItem message, string boundaryTopic)
    {
        if (message.Body != null && message.Body.Contains(boundaryTopic))
        {
            return true;
        }
        return false;
    }

    public static MessageItem GetEchoMessage(MessageItem originalMessage)
    {
        return new MessageItem
        {
            Body = "Echo - " + originalMessage.Body,
            Created = DateTime.Now,
            IsMyMessage = false,
            Attachments = originalMessage.Attachments
        };
    }
    //i need a method that calls chatgpt with a particular prompt that I will pass it
    private static MessageItem GetGPTResponse(MessageItem originalMessage, BoundaryTopic topic)
    {
        //construct the call to chatgpt

        //return the response

        return new MessageItem();
    }
}
