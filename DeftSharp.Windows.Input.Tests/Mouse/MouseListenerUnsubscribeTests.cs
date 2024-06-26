﻿namespace DeftSharp.Windows.Input.Tests.Mouse;

public sealed class MouseListenerUnsubscribeTests
{
    private async void RunListenerTest(Action<MouseListener> onTest)
    {
        var mouseListener = new MouseListener();
        await Task.Run(() => onTest(mouseListener));

        Assert.False(mouseListener.IsListening,
            "The Unregister function is not called after unsubscribing from all events.");
    }

    [Fact]
    public void MouseListener_SubscribeUnsubscribe()
    {
        RunListenerTest(listener =>
        {
            listener.Subscribe(MouseEvent.LeftButtonDown, () => { });
            listener.Unsubscribe(MouseEvent.LeftButtonDown);
        });
    }

    [Fact]
    public void MouseListener_SubscribeUnsubscribeAll()
    {
        RunListenerTest(listener =>
        {
            listener.Subscribe(MouseEvent.LeftButtonDown, () => { });
            listener.Unsubscribe();
        });
    }

    [Fact]
    public void MouseListener_SubscribeManyUnsubscribeAll()
    {
        RunListenerTest(listener =>
        {
            listener.Subscribe(MouseEvent.LeftButtonDown, () => { });
            listener.Subscribe(MouseEvent.RightButtonUp, () => { });
            listener.Subscribe(MouseEvent.RightButtonDown, () => { });
            listener.Subscribe(MouseEvent.RightButtonUp, () => { });
            listener.Unsubscribe();
        });
    }

    [Fact]
    public void MouseListener_SubscribeManyUnsubscribeMany()
    {
        RunListenerTest(listener =>
        {
            listener.Subscribe(MouseEvent.LeftButtonDown, () => { });
            listener.Subscribe(MouseEvent.RightButtonUp, () => { });
            listener.Subscribe(MouseEvent.RightButtonDown, () => { });
            listener.Subscribe(MouseEvent.RightButtonUp, () => { });

            listener.Unsubscribe(MouseEvent.LeftButtonDown);
            listener.Unsubscribe(MouseEvent.RightButtonUp);
            listener.Unsubscribe(MouseEvent.RightButtonDown);
            listener.Unsubscribe(MouseEvent.RightButtonUp);
        });
    }

    [Fact]
    public void MouseListener_UnsubscribeAll()
    {
        RunListenerTest(listener => listener.Unsubscribe());
    }

    [Fact]
    public void MouseListener_Empty()
    {
        RunListenerTest(_ => { });
    }
}